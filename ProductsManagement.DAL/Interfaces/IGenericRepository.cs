using ProductsManagement.DAL.Entities;
using ProductsManagement.DAL.Repositories;

namespace ProductsManagement.DAL.Interfaces;

public interface IGenericRepository<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetAsync(int id);
    public Task AddAsync(T model);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(T model);
}