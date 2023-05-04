using System.IO.Enumeration;
using System.Text.RegularExpressions;
using AutoMapper;
using ProductsManagement.BLL.DTO.Requests;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Services.Abstract;

namespace ProductsManagement.BLL.Services.Concrete;

public class ProductsService : IProductsService
{
    private static readonly TimeSpan RequestFrequencyDelay = TimeSpan.FromSeconds(2);
    
    private readonly IMapper _mapper;
    private readonly IAliexpressProductsService _aliexpressService;
    private readonly IAmazonProductsService _amazonService;
    private readonly IGoogleSearchService _googleSearchService;

    public ProductsService(IMapper mapper, IAliexpressProductsService aliexpressService,
        IAmazonProductsService amazonService, IGoogleSearchService googleSearchService)
    {
        _mapper = mapper;
        _aliexpressService = aliexpressService;
        _amazonService = amazonService;
        _googleSearchService = googleSearchService;
    }

    public async Task<IEnumerable<ProductOfferResponse>> GetProductOffers(ProductOffersRequest request)
    {
        request.Region = "US"; // Temporary
        var offers = new List<ProductOfferResponse>();

        var aliResponses =
            await _aliexpressService.SearchByImage(request.ProductImageUrl, null, null, request.Region);
        aliResponses = aliResponses.Take(20).ToList();
        int i = 0;
        var requestStartTime = DateTime.MinValue;
        foreach (var response in aliResponses)
        {
            var requestElapsedTime = DateTime.UtcNow - requestStartTime;
            var remainingDelay = RequestFrequencyDelay - requestElapsedTime;

            // Delay for the remaining time (if any)
            if (remainingDelay > TimeSpan.Zero)
            {
                await Task.Delay(remainingDelay);
            }
            requestStartTime = DateTime.UtcNow;
            
            var detail = await _aliexpressService.ProductDetailForOfferAsync(response.ProductId, request.Region, i);
            var offer = _mapper.Map<ProductDetailForOfferResponse, ProductOfferResponse>(detail);
            offer.ImgUrl = response.ImageUrl;
            offer.ShippingTo = request.Region;
            offer.ProductPrice = response.PriceUSD;
            offer.TotalPrice = response.PriceUSD + (detail.ShippingPrice ?? 0);
            offer.SellerUrl = response.Url;
            offers.Add(offer);
            i++;
        }

        var googleResponses = await _googleSearchService.SearchByImage(request.ProductImageUrl);
        googleResponses = googleResponses.Where(resp =>
                resp.Price != null /*|| resp.Source.Contains("amazon"))*/ && !resp.Source.Contains("aliexpress"))
            .Take(30).ToList();
        foreach (var response in googleResponses)
        {
            ProductOfferResponse offer;
            // if (response.Source.Contains("amazon"))
            // {
            //     var asinMatch = Regex.Match(response.Link, @"/dp/([A-Z0-9]{10})");
            //     if (!asinMatch.Success)
            //         continue;
            //
            //     var productAsin = asinMatch.Groups[1].Value;
            //     var detail = await _amazonService.ProductDetailForOfferAsync(productAsin, request.Region, i);
            //     if (detail.ProductPrice == null)
            //         continue;
            //     
            //     offer = _mapper.Map<ProductDetailForOfferResponse, ProductOfferResponse>(detail);
            //     offer.ImgUrl = response.Thumbnail;
            //     offer.ShippingTo = request.Region;
            //     offer.ProductPrice = detail.ProductPrice.Value;
            //     offer.TotalPrice = detail.ProductPrice.Value + (detail.ShippingPrice ?? 0);
            //     offer.SellerUrl = response.Link;
            //     i++;
            // }
            // else
            // {
            var priceWitCurrMatch = Regex.Match(response.Price!.Value, @"(\D*)(\d+\.\d{2})");
            if (!priceWitCurrMatch.Success || priceWitCurrMatch.Groups.Count != 3)
                continue;
            var currency = priceWitCurrMatch.Groups[1].Value;
            if (!currency.Contains('$'))
                continue;
            var price = float.Parse(priceWitCurrMatch.Groups[2].Value);

            offer = new ProductOfferResponse
            {
                ImgUrl = response.Thumbnail,
                ShippingTo = request.Region,
                ProductPrice = price,
                TotalPrice = price,
                SellerUrl = response.Link
            };
            // }

            offers.Add(offer);
        }

        var avg = offers.Average(offer => offer.TotalPrice);
        var threshold = avg - avg * 0.5;
        return offers
            .Where(offer => offer.TotalPrice >= threshold)
            .OrderBy(offer => offer.TotalPrice).ToList();
    }

    public async Task<IEnumerable<ProductSearchResponse>> ProductSearch(string query, int pageNumber, string? region)
    {
        var aliexpressProducts =
            await _aliexpressService.SearchAsync(query, pageNumber, region);
        
        var amazonProducts =
            await _amazonService.SearchAsync(query, pageNumber, region);

        var random = new Random();
        var shuffledProductsList = aliexpressProducts.Concat(amazonProducts).OrderBy(x => random.Next()).ToList();

        return shuffledProductsList;
    }
}