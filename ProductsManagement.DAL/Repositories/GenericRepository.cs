using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Interfaces;

namespace ProductsManagement.DAL.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ProductsDbContext _dbContext;

    public GenericRepository(ProductsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<T> GetAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        
        if (entity == null)
        {
            throw new Exception($"Entity({typeof(T)}) with {id} not found.");
        }
        
        return entity;
    }
    
    public async Task AddAsync(T model)
    {
        await _dbContext.Set<T>().AddAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        
        if (entity == null)
        {
            throw new Exception($"Entity({typeof(T)}) with {id} not found.");
        }
        
        _dbContext.Set<T>().Remove(entity);
    }

    public async Task UpdateAsync(T model)
    {
        await Task.Run(() => _dbContext.Set<T>().Update(model));
    }

}