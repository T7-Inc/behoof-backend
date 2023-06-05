using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class ProductPhotosRepository : GenericRepository<ProductPhotos>, IProductPhotosRepository
{
    private readonly DbSet<ProductPhotos> _productPhotos;
    
    public ProductPhotosRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _productPhotos = dbContext.Set<ProductPhotos>();
    }

    public async Task<IEnumerable<ProductPhotos>> GetPhotosOfProduct(int productId)
    {
        return await _productPhotos.Where(p => p.TrackedProductsId == productId).ToListAsync();
    }
}