using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface ITrackedProductsRepository : IGenericRepository<TrackedProducts>
{
    public Task<TrackedProducts> GetAllInformationAboutTrackedProduct(int id);
}