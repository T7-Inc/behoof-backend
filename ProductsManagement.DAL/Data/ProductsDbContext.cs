using Microsoft.EntityFrameworkCore;

namespace ProductsManagement.DAL.Data;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
        : base(options)
    {
    }
}