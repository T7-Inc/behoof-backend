using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductPhotosRepository
{
    public Task<IEnumerable<ProductPhotos>> GetPhotosOfProduct(int productId);
}