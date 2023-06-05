using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductPhotosRepository : IGenericRepository<ProductPhotos>
{
    public Task<IEnumerable<ProductPhotos>> GetPhotosOfProduct(int productId);
}