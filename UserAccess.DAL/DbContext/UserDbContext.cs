using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserAccess.DAL.Entities;

namespace UserAccess.DAL.DbContext;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions options)
        : base(options)
    {
        
    }
    
}