using ProductsManagement.BLL.DTO.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IAliexpressProductsService : IMarketplaceProductsService
{
    Task<ProductDetailForOfferResponse> ProductDetailForOfferAsync(string productId, string? region, int? n);
    
    Task<IEnumerable<ProductSearchResponse>> SearchByImage(string imgUrl, string? sort, string? categoryId,
        string? region);
}