using ProductsManagement.BLL.DTO.Requests;
using ProductsManagement.BLL.DTO.Responses;

namespace ProductsManagement.BLL.Services.Abstract;

public interface IProductsService
{
    Task<IEnumerable<ProductOfferResponse>> GetProductOffers(ProductOffersRequest request);
}