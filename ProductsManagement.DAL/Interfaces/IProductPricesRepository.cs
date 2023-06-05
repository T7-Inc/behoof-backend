using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductPricesRepository : IGenericRepository<ProductPrices>
{
    public Task<IList<ProductPrices>> getAllPricesOfProduct(int productId);
}