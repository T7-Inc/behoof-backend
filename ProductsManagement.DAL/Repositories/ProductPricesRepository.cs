using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class ProductPricesRepository : GenericRepository<ProductPrices>, IProductPricesRepository
{
    private readonly DbSet<ProductPrices> _producPrices;
    
    public ProductPricesRepository(ProductsDbContext dbContext, DbSet<ProductPrices> producPrices) : base(dbContext)
    {
        _producPrices = producPrices;
    }

    public async Task<IList<ProductPrices>> getAllPricesOfProduct(int productId)
    {
        return await _producPrices.Where(p => p.TrackedProductsId == productId).ToListAsync();
    }
}