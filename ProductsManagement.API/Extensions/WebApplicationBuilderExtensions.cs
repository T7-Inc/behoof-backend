using Microsoft.EntityFrameworkCore;
using ProductsManagement.DAL.Data;

namespace ProductsManagement.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddProductsManagement(this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.Services.AddDbContext<ProductsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DataBaseConnection"));
        });
        
        builder.Services.AddAuthorization();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        return builder;
    }
}