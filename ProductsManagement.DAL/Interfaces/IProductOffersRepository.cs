using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductOffersRepository : IGenericRepository<ProductOffers>
{
    public Task<IEnumerable<ProductOffers>> GetAllOffersOfProduct(int productId);
    public Task<IEnumerable<ProductOffers>> GetInstockOffersOfProduct(int productId);
}