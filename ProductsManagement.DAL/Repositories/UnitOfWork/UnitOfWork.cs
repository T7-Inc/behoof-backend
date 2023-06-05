using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsDbContext dbContext;
    public IProductOffersRepository productOffersRepository { get; set; }
    public IProductPhotosRepository productPhotosRepository { get; }
    public IProductPricesRepository productPricesRepository { get; }
    public IProductReviewsRepository productReviewsRepository { get; }
    public IRuleSetRepository ruleSetRepository { get; }
    public ITrackedProductsRepository trackedProductsRepository { get; }
    public IUserLikedProductsRepository userLikedProductsRepository { get; }
    public IUserTrackedProductsRepository userTrackedProductsRepository { get; }

    
    public UnitOfWork(
        ProductsDbContext dbContext,
        IProductOffersRepository productOffersRepository,
        IProductPhotosRepository productPhotosRepository,
        IProductPricesRepository productPricesRepository,
        IProductReviewsRepository productReviewsRepository,
        IRuleSetRepository ruleSetRepository,
        ITrackedProductsRepository trackedProductsRepository,
        IUserLikedProductsRepository userLikedProductsRepository,
        IUserTrackedProductsRepository userTrackedProductsRepository)

    {
        this.dbContext = dbContext;
        this.productOffersRepository = productOffersRepository;
        this.productPhotosRepository = productPhotosRepository;
        this.productPricesRepository = productPricesRepository;
        this.productReviewsRepository = productReviewsRepository;
        this.ruleSetRepository = ruleSetRepository;
        this.trackedProductsRepository = trackedProductsRepository;
        this.userLikedProductsRepository = userLikedProductsRepository;
        this.userTrackedProductsRepository = userTrackedProductsRepository;
    }
    
    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}