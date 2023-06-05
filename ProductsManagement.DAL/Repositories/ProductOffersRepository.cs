using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class ProductOffersRepository : GenericRepository<ProductOffers>, IProductOffersRepository
{
    private readonly DbSet<ProductOffers> _productOffers;
    
    public ProductOffersRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _productOffers = dbContext.Set<ProductOffers>();
    }

    public async Task<IEnumerable<ProductOffers>> GetAllOffersOfProduct(int productId)
    {
        return await _productOffers.Where(p => p.ProductId == productId).ToListAsync();
    }
    
    public async Task<IEnumerable<ProductOffers>> GetInstockOffersOfProduct(int productId)
    {
        return await _productOffers.Where(p => p.ProductId == productId && p.Instock).ToListAsync();
    }
}