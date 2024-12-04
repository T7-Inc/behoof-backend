using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class UserTrackedProductsRepository : GenericRepository<UserTrackedProducts>, IUserTrackedProductsRepository
{
    private readonly DbSet<UserTrackedProducts> _userTrackedProducts;
    
    public UserTrackedProductsRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _userTrackedProducts = dbContext.Set<UserTrackedProducts>();
    }
    
    public async Task<IEnumerable<UserTrackedProducts>> GetInfoAboutProductsTrackedByUser(string userId)
    {
        var trackedProducts = await _userTrackedProducts.Include(u => u.TrackedProduct.ProductOffers)
            .Include(u => u.TrackedProduct.ProductPhotos)
            .Include(u => u.TrackedProduct.ProductPrices)
            .Where(tracked => tracked.UserId == userId).ToListAsync();

        return trackedProducts;
    }
    
    public async Task<IList<UserTrackedProducts>> GetProductsTrackedByUser(string userId)
    {
        return await _userTrackedProducts.Where(p => p.UserId == userId).ToListAsync();
    }
}