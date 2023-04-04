using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IProductReviewsRepository
{
    public Task<IEnumerable<ProductReviews>> GetReviewsOfProduct(int productId);
}