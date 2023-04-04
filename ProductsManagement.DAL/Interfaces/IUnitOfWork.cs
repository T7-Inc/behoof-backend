namespace ProductsManagement.DAL.Interfaces;

public interface IUnitOfWork
{
    public IProductOffersRepository productOffersRepository { get; set; }
    public IProductPhotosRepository productPhotosRepository { get; }
    public IProductPricesRepository productPricesRepository { get; }
    public IProductReviewsRepository productReviewsRepository { get; }
    public IRuleSetRepository ruleSetRepository { get; }
    public ITrackedProductsRepository trackedProductsRepository { get; }
    public IUserLikedProductsRepository userLikedProductsRepository { get; }
    public IUserTrackedProductsRepository userTrackedProductsRepository { get; }

    public Task SaveChangesAsync();
}