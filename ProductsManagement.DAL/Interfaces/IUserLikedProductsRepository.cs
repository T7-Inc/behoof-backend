using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Interfaces;

public interface IUserLikedProductsRepository
{
    public Task<IEnumerable<UserLikedProducts>> GetUserLikedProducts(string userId);
    public Task<IEnumerable<UserLikedProducts>> GetInfoAboutProductsLikedByUser(string userId);
}