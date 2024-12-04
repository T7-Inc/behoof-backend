using ProductsManagement.DAL.Data.Configuration;
using ProductsManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductsManagement.DAL.Data;

public class ProductsDbContext : DbContext

    
{ 
    public virtual DbSet<ProductOffers> Productoffers { get; set; } = null!;
    public virtual DbSet<ProductPhotos> Productphotos { get; set; } = null!;
    public virtual DbSet<ProductPrices> Productprices { get; set; } = null!;
    public virtual DbSet<ProductReviews> Reviewproducts { get; set; } = null!;
    public virtual DbSet<RuleSet> Rulesets { get; set; } = null!;
    public virtual DbSet<TrackedProducts> Trackedproducts { get; set; } = null!;
    public virtual DbSet<UserLikedProducts> Userlikedproducts { get; set; } = null!;
    public virtual DbSet<UserTrackedProducts> Usertrackedproducts { get; set; } = null!;
    private readonly IConfiguration _configuration;
    
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProductOffersConfig());
        modelBuilder.ApplyConfiguration(new ProductPhotosConfig());
        modelBuilder.ApplyConfiguration(new ProductPricesConfig());
        modelBuilder.ApplyConfiguration(new ProductReviewsConfig());
        modelBuilder.ApplyConfiguration(new RuleSetConfig());
        modelBuilder.ApplyConfiguration(new TrackedProductsConfig());
        modelBuilder.ApplyConfiguration(new UserLikedProductsConfig());
        modelBuilder.ApplyConfiguration(new UserTrackedProductsConfig());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { 
            optionsBuilder.UseNpgsql(_configuration["ConnectionStrings:DataBaseConnection"]);
        }
    }
}