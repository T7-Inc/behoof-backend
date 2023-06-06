using System.Globalization;
using AutoMapper;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.Enums;
using ProductsManagement.BLL.Helpers;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Google.Responses;

namespace ProductsManagement.BLL.Configurations;

public class AutoMapperProfile : Profile
{
    private const string AliexpressBaseUrl = "https://www.aliexpress.com/";

    public AutoMapperProfile()
    {
        CreateProductsMaps();
        CreateAliexpressMaps();
        CreateAmazonMaps();
        CreateGoogleMaps();
    }

    private void CreateProductsMaps()
    {
        CreateMap<ProductDetailForOfferResponse, ProductOfferResponse>();
    }

    private void CreateAliexpressMaps()
    {
        CreateMap<AliexpressSearchResult, ProductSearchResponse>()
            .ForMember(response => response.MarketplaceIndex,
                options =>
                    options.MapFrom(_ => MarketplacesEnum.Aliexpress))
            .ForMember(response => response.ProductId,
                options =>
                    options.MapFrom(result => result.Item.ItemId))
            .ForMember(response => response.ImageUrl,
                options =>
                    options.MapFrom(result => "https:" + result.Item.Image))
            .ForMember(response => response.Title,
                options =>
                    options.MapFrom(result => result.Item.Title))
            .ForMember(response => response.PriceUSD,
                options =>
                    options.MapFrom(result => result.Item.Sku.Def.PromotionPrice))
            .ForMember(response => response.Url,
                options =>
                    options.MapFrom(result => AliexpressBaseUrl + "item/" + result.Item.ItemId + ".html"));

        CreateMap<AliexpressProductDetailResult, ProductDetailResponse>()
            .ForMember(response => response.ProductId,
                options =>
                    options.MapFrom(result => result.ItemId))
            .ForMember(response => response.Images,
                options =>
                    options.MapFrom(result => result.Images.Select(imageUrl => "https:" + imageUrl)));

        CreateMap<AliexpressProductDescriptionResult, DescriptionResponse>()
            .ForMember(response => response.Images,
                options =>
                    options.MapFrom(result => 
                        result.Description.Images.Select(imageUrl => "https:" + imageUrl)))
            .ForMember(response => response.Properties,
                options =>
                    options.MapFrom(result => result.Properties.List
                        .DistinctBy(prop => prop.Name)
                        .ToDictionary(prop => prop.Name, prop => prop.Value)))
            .ForMember(response => response.Text,
                options =>
                    options.MapFrom(result => string.Join('\n', result.Description.Text)));

        CreateMap<AliexpressProductDetailForOfferResult, ProductDetailForOfferResponse>()
            .ForMember(response => response.ShippingFrom,
                options =>
                    options.MapFrom(result => result.Delivery.ShippingFrom))
            .ForMember(response => response.ShippingPrice,
                options =>
                    options.MapFrom(result => FloatHelpers.ConvertToFloatNullable(result.Delivery.ShippingList.First().ShippingFee)))
            .ForMember(response => response.SellerRating,
                options =>
                    options.MapFrom(result => FloatHelpers.ConvertToFloatNullable(result.Seller.StoreRating)))
            .ForMember(response => response.Available,
                options =>
                    options.MapFrom(result => result.Item.Sku.Def.Quantity > 0));
    }

    private void CreateAmazonMaps()
    {
        CreateMap<AmazonSearchResult, ProductSearchResponse>()
            .ForMember(dest => dest.MarketplaceIndex,
                opt => opt.MapFrom(_ => MarketplacesEnum.Amazon))
            .ForMember(dest => dest.ImageUrl,
                opt => 
                    opt.MapFrom(src => 
                        src.Images.FirstOrDefault() != null ? src.Images.FirstOrDefault()!.Image : ""))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.PriceUSD,
                opt => opt.MapFrom(src => FloatHelpers.ConvertToFloat(src.Price.Amount)))
            .ForMember(dest => dest.ProductId,
                opt => opt.MapFrom(src => src.Asin))
            .ForMember(dest => dest.Url,
                opt => opt.Ignore());

        CreateMap<AmazonProductDetailResult, ProductDetailResponse>()
            .ForMember(response => response.ProductId,
                options =>
                    options.MapFrom(result => result.Asin))
            .ForMember(response => response.Title,
                options =>
                    options.MapFrom(result => result.Title))
            .ForMember(response => response.Images,
                options =>
                    options.MapFrom(result => result.Images.Select(img => img.Hi_res)));

        CreateMap<AmazonProductDetailForOfferResult, ProductDetailForOfferResponse>()
            .ForMember(response => response.ProductPrice,
                options =>
                    options.MapFrom(result => FloatHelpers.ConvertToFloatNullable(result.Price.Amount)))
            .ForMember(response => response.SellerRating,
                options =>
                    options.MapFrom(result => result.Reviews.AvgRating))
            .ForMember(response => response.Available,
                options =>
                    options.MapFrom(result => result.SoldBy.Availability == "0"));
    }

    private void CreateGoogleMaps()
    {
        CreateMap<GoogleSearchResult, ProductOfferResponse>()
            .ForMember(response => response.ImgUrl,
                options =>
                    options.MapFrom(result => result.Thumbnail))
            .ForMember(response => response.ProductPrice,
                options =>
                    options.MapFrom(result => result.Price != null ? result.Price.Value : null))
            .ForMember(response => response.SellerUrl,
                options =>
                    options.MapFrom(result => result.Link));
    }
}