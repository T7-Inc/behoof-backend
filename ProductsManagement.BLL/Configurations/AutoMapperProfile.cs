using AutoMapper;
using ProductsManagement.BLL.DTO.Responses;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Aliexpress.Responses;
using ProductsManagement.BLL.ThirdPartyAPIsDTO.Amazon.Responses;

namespace ProductsManagement.BLL.Configurations;

public class AutoMapperProfile : Profile
{
    private const string AliexpressBaseUrl = "https://www.aliexpress.com/";

    public AutoMapperProfile()
    {
        CreateAliexpressMaps();
    }

    private void CreateAliexpressMaps()
    {
        CreateMap<AliexpressSearchResult, ProductSearchResponse>()
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
                    options.MapFrom(result => result.Images.Select(imageUrl => "https:" + imageUrl)))
            .ForMember(response => response.CategoryId,
                options =>
                    options.MapFrom(result => result.CatId));

        CreateMap<AmazonSearchResult, ProductSearchResponse>()
            .ForMember(response => response.ProductId,
                options =>
                    options.MapFrom(result => result.Asin))
            .ForMember(response => response.Title,
                options =>
                    options.MapFrom(result => result.Title))
            .ForMember(response => response.PriceUSD,
                options =>
                    options.MapFrom(result => result.ProductPrice.ListPrice));

        CreateMap<AmazonProductDetailResult, ProductSearchResponse>()
            .ForMember(response => response.ProductId,
                options =>
                    options.MapFrom(result => result.Asin))
            .ForMember(response => response.Title,
                options =>
                    options.MapFrom(result => result.Title))
            .ForMember(response => response.Url,
                options =>
                    options.MapFrom(result => result.Link));

    }
}