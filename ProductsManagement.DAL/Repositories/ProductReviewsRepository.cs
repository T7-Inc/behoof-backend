using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class ProductReviewsRepository : GenericRepository<ProductReviews>, IProductReviewsRepository
{
    private readonly DbSet<ProductReviews> _productReviews;
    
    public ProductReviewsRepository(ProductsDbContext dbContext, DbSet<ProductReviews> productReviews) : base(dbContext)
    {
        _productReviews = productReviews;
    }
    
    public async Task<IEnumerable<ProductReviews>> GetReviewsOfProduct(int productId)
    {
        return await _productReviews.Where(p => p.TrackedProductsId == productId).ToListAsync();
    }
}