using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.WebUtilities;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;

namespace ProductsManagement.BLL.Services.Concrete;

public class AliexpressProductsService : IAliexpressProductsService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;

    public AliexpressProductsService(HttpClient httpClient, IMapper mapper)
    {
        _httpClient = httpClient;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductSearchResponse>> SearchAsync(string query, int page, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["q"] = query,
            ["page"] = page.ToString(),
            ["sort"] = "default",
            ["locale"] = "en_US", 
            ["currency"] = "USD"
        };
        if(region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_search", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("E:\\Projects\\Behoof\\storedSearchResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<AliexpressSearchResult>>(
            responseContent, "result.resultList");
        return searchContent.Select(_mapper.Map<AliexpressSearchResult, ProductSearchResponse>);
    }
    
    public async Task<ProductDetailResponse> ProductDetailAsync(string productId, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["itemId"] = productId
        };
        if(region != null)
            parameters.Add("region", region);
        
        var uri = QueryHelpers.AddQueryString("item_detail", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDetailResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var productDetail = JsonParseHelper.ObjectFromJsonPropertyName<AliexpressProductDetailResult>(
            responseContent, "result.item");
        var detail = _mapper.Map<AliexpressProductDetailResult, ProductDetailResponse>(productDetail);
        detail.Description = await ProductDescriptionAsync(productId);
        return detail;
    }
    
    private async Task<DescriptionResponse> ProductDescriptionAsync(string productId)
    {
        var parameters = new Dictionary<string, string>
        {
            ["itemId"] = productId
        };
        
        var uri = QueryHelpers.AddQueryString("item_desc", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDescriptionResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var productDescription = JsonParseHelper.ObjectFromJsonPropertyName<AliexpressProductDescriptionResult>(
            responseContent, "result.item");
        return _mapper.Map<AliexpressProductDescriptionResult, DescriptionResponse>(productDescription);
    }

    public async Task<ProductDetailForOfferResponse> ProductDetailForOfferAsync(string productId, string? region, int? n)
    {
        var parameters = new Dictionary<string, string>
        {
            ["itemId"] = productId
        };
        if(region != null)
            parameters.Add("region", region);

        var uri = QueryHelpers.AddQueryString("item_detail", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedProductDetailForOfferResponse.json");
        // var responseContent = "";
        // for (var i = 0; i <= n; i++)
        // {
        //     responseContent = (await r.ReadLineAsync())!;
        //     if (i == n)
        //         break;
        // }
        // if (responseContent[^1] == ',')
        //     responseContent = responseContent.Remove(responseContent.Length-1);

        var productDetail = JsonParseHelper.ObjectFromJsonPropertyName<AliexpressProductDetailForOfferResult>(
            responseContent, "result");
        var priceUsdStr = productDetail.Item.Sku.Def.PromotionPrice;
        float? priceUsd = null;
        if (!string.IsNullOrEmpty(priceUsdStr))
        {
            var match = Regex.Match(priceUsdStr, @"^(\d+[\.,]\d{2})");
            if (match.Success)
                priceUsd = FloatHelpers.ConvertToFloatNullable(match.Value);
        }

        var result = 
            _mapper.Map<AliexpressProductDetailForOfferResult, ProductDetailForOfferResponse>(productDetail);
        result.ProductPrice = priceUsd;
        return result;
    }

    public async Task<IEnumerable<ProductSearchResponse>> SearchByImage(string imgUrl, string? sort, string? categoryId, string? region)
    {
        var parameters = new Dictionary<string, string>
        {
            ["imgUrl"] = imgUrl
        };
        if(sort != null)
            parameters.Add("sort", sort);
        if(categoryId != null)
            parameters.Add("categoryId", categoryId);
        if(region != null)
            parameters.Add("region", region);
        
        var uri = QueryHelpers.AddQueryString("item_search_image", parameters);
        var response = await _httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();
        
        // var r = new StreamReader("StoredJsonAPIResponses/Aliexpress/storedSearchByImageResponse.json");
        // var responseContent = await r.ReadToEndAsync();
        
        var searchContent = JsonParseHelper.ObjectFromJsonPropertyName<List<AliexpressSearchResult>>(
            responseContent, "result.resultList");
        return searchContent.Select(_mapper.Map<AliexpressSearchResult, ProductSearchResponse>);
    }
}