using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SendGrid.Extensions.DependencyInjection;
using UserAccess.BLL.Interfaces;
using UserAccess.BLL.Services;
using UserAccess.DAL.DbContext;
using UserAccess.DAL.Entities;

namespace UserAccess.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddUserAccessManagement(this WebApplicationBuilder builder,
        IConfiguration configuration)
    {
        builder.Services.AddDbContext<UserDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DataBaseConnection"));
        });

        builder.Services.AddIdentityCore<User>(options => { })
            .AddEntityFrameworkStores<UserDbContext>()
            .AddSignInManager<SignInManager<User>>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidateIssuer = true,
                };
            });
        
        builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<UserDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);
        
        builder.Services.AddSendGrid(options =>
            options.ApiKey = builder.Configuration.GetValue<string>("SendGridApi:Key")
                             ?? throw new Exception("The 'SendGridApiKey' is not configured")
        );
        Console.WriteLine(builder.Configuration.GetValue<string>("SendGridApi:Key"));
        builder.Services.AddTransient<IEmailService, EmailService>();
        builder.Services.AddAuthorization();

        builder.Services.AddControllers()
            .AddApplicationPart(typeof(WebApplicationBuilderExtensions).Assembly);

        builder.Services.AddScoped<ITokenService, TokenService>();

        return builder;
    }
}