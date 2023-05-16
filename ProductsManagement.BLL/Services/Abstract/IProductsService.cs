using ProductsManagement.BLL.DTO.Requests;
using ProductsManagement.BLL.DTO.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IProductsService
{
    Task<IEnumerable<ProductSearchResponse>> ProductSearch(string query, int pageNumber, string? region);

    Task<ProductDetailResponse> GetProductDetail(string productId, int marketplaceId);
    
    Task<IEnumerable<ProductOfferResponse>> GetProductOffers(ProductOffersRequest request);
}