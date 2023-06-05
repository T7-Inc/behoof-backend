using System.Net.Http.Headers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.BLL.Configurations;
using ProductsManagement.BLL.Services.Abstract;
using ProductsManagement.BLL.Services.Concrete;
using ProductsManagement.DAL.Data;
using ProductsManagement.DAL.Interfaces;
using ProductsManagement.DAL.Repositories;
using ProductsManagement.DAL.Repositories.UnitOfWork;

namespace ProductsManagement.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddProductsManagement(this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.Services.AddDbContext<ProductsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ProductDbConnection"));
        });
        
        var mapperConfig = new MapperConfiguration(mc =>
            mc.AddProfile(new AutoMapperProfile()));
        var mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        
        builder.Services.AddHttpClient<IAliexpressProductsService, AliexpressProductsService>(client =>
        {
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Key", builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Key"]);
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Host", builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Host"]);
            client.BaseAddress = new Uri(builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Url"]);
        });
        
        builder.Services.AddHttpClient<IAmazonProductsService, AmazonProductsService >(client =>
        {
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Key", builder.Configuration["ThirdPartyAPIs:AmazonAPI:Key"]);
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Host", builder.Configuration["ThirdPartyAPIs:AmazonAPI:Host"]);
            client.BaseAddress = new Uri(builder.Configuration["ThirdPartyAPIs:AmazonAPI:Url"]);
        });
        
        builder.Services.AddHttpClient<IGoogleSearchService, GoogleSearchService>(client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["ThirdPartyAPIs:GoogleAPI:Url"]);
        });
        
        builder.Services.AddTransient<IUserLikedProductsRepository, UserLikedProductsRepository>();
        builder.Services.AddTransient<IProductOffersRepository, ProductOffersRepository>();
        builder.Services.AddTransient<IProductPhotosRepository, ProductPhotosRepository>();
        builder.Services.AddTransient<IProductPricesRepository, ProductPricesRepository>();
        builder.Services.AddTransient<IProductReviewsRepository, ProductReviewsRepository>();
        builder.Services.AddTransient<IRuleSetRepository, RuleSetRepository>();
        builder.Services.AddTransient<ITrackedProductsRepository, TrackedProductsRepository>();
        builder.Services.AddTransient<IUserTrackedProductsRepository, UserTrackedProductsRepository>();
        
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<IProductsService, ProductsService>();

        builder.Services.AddAuthorization();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        return builder;
    }
}