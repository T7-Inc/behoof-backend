﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.BLL.Configurations;
using ProductsManagement.BLL.Services.Concrete;
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
        
        var mapperConfig = new MapperConfiguration(mc =>
            mc.AddProfile(new AutoMapperProfile()));
        var mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);
        builder.Services.AddTransient<AliexpressProductsService>();
        builder.Services.AddHttpClient<AliexpressProductsService>(client =>
        {
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Key", builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Key"]);
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Host", builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Host"]);
            client.BaseAddress = new Uri(builder.Configuration["ThirdPartyAPIs:AliexpressAPI:Url"]);
        });
        builder.Services.AddTransient<AmazonProductService>();
        builder.Services.AddHttpClient<AmazonProductService >(client =>
        {
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Key", builder.Configuration["ThirdPartyAPIs:AmazonAPI:Key"]);
            client.DefaultRequestHeaders.Add(
                "X-RapidAPI-Host", builder.Configuration["ThirdPartyAPIs:AmazonAPI:Host"]);
            client.BaseAddress = new Uri(builder.Configuration["ThirdPartyAPIs:AmazonAPI:Url"]);
        });
        
        builder.Services.AddAuthorization();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        return builder;
    }
}