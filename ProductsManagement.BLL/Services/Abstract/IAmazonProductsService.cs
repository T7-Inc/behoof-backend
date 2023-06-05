using ProductsManagement.BLL.DTO.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IAmazonProductsService : IMarketplaceProductsService
{
    Task<ProductDetailForOfferResponse> ProductDetailForOfferAsync(string productId, string? region, int? n);
}