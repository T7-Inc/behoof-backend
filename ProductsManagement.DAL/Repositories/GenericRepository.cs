using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ProductsDbContext _dbContext;

    public GenericRepository(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(object id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task DeleteAsync(object id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task ReplaceAsync(T model)
    {
        _dbContext.Entry(model).State = EntityState.Modified;
    }

    public async Task AddAsync(T model)
    {
        await _dbContext.Set<T>().AddAsync(model);
    }

}