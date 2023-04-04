using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductPricesRepository
{
    public Task<IList<ProductPrices>> getAllPricesOfProduct(int productId);
}