namespace UserAccess.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddUserAccessManagement(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        return builder;
    }
}