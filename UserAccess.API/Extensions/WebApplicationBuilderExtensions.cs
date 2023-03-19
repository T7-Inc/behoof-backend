using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserAccess.DAL.DbContext;
using UserAccess.DAL.Entities;

namespace UserAccess.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddUserAccessManagement(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DataBaseConnection"));
        });

        builder.Services.AddIdentityCore<User>(options => { })
            .AddEntityFrameworkStores<UserDbContext>()
            .AddSignInManager<SignInManager<User>>();

        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        return builder;
    }
}