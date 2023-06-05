using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductReviewsRepository : IGenericRepository<ProductReviews>
{
    public Task<IEnumerable<ProductReviews>> GetReviewsOfProduct(int productId);
}