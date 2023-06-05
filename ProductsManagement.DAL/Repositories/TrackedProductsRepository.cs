using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class TrackedProductsRepository : GenericRepository<TrackedProducts>, ITrackedProductsRepository
{
    private readonly DbSet<TrackedProducts> _trackedProducts;
    
    public TrackedProductsRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _trackedProducts = dbContext.Set<TrackedProducts>();
    }
    
    public async Task<TrackedProducts> GetAllInformationAboutTrackedProduct(int id)
    {
        var trackedProduct = await _trackedProducts.Include(p => p.ProductOffers)
            .Include(p => p.ProductPhotos)
            .Include(p => p.ProductPrices)
            .Include(p => p.ReviewProducts)
            .SingleOrDefaultAsync(tracked => tracked.Id == id);

        if (trackedProduct == null)
        {
            throw new Exception($"TrackedProduct with {id} not found.");
        }

        return trackedProduct;
    }
}