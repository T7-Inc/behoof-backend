using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public class RuleSetRepository : GenericRepository<RuleSet>, IRuleSetRepository
{
    private readonly DbSet<ProductOffers> _ruleSets;
    
    public RuleSetRepository(ProductsDbContext dbContext) : base(dbContext)
    {
        _ruleSets = dbContext.Set<ProductOffers>();;
    }
}