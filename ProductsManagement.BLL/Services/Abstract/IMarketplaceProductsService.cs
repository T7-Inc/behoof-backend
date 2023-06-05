using ProductsManagement.BLL.DTO.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IMarketplaceProductsService
{
    Task<IEnumerable<ProductSearchResponse>> SearchAsync(string query, int page, string? region);

    Task<ProductDetailResponse> ProductDetailAsync(string productId, string? region);
}