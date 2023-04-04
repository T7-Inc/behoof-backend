using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface ITrackedProductsRepository
{
    public Task<TrackedProducts> GetAllInformationAboutTrackedProduct(int id);
}