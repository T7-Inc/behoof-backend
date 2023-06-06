using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class UserLikedProductsRepository : GenericRepository<UserLikedProducts>, IUserLikedProductsRepository
{
    private readonly DbSet<UserLikedProducts> _userLikedProducts;
    
    public UserLikedProductsRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _userLikedProducts = dbContext.Set<UserLikedProducts>();
    }
    
    public async Task<IEnumerable<UserLikedProducts>> GetUserLikedProducts(string userId)
    {
        return await _userLikedProducts.Where(u => u.UserId == userId).ToListAsync();
    }
    
    public async Task<IEnumerable<UserLikedProducts>> GetInfoAboutProductsLikedByUser(string userId)
    {
        var likedProducts = await _userLikedProducts.Include(u => u.Product)
            .Include(u => u.Product.ProductPhotos)
            .Where(tracked => tracked.UserId == userId).ToListAsync();

        return likedProducts;
    }
}