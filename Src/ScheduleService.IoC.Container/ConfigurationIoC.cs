using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ScheduleService.Application.CommandHandler;
using ScheduleService.Application.CommandHandler.Services;
using ScheduleService.Application.CommandHandler.Services.Models;
using ScheduleService.Application.Repository;
using ScheduleService.Infrastructure.Context.Contexts;
using ScheduleService.Infrastructure.Repository;
using ServiceStack.Redis;
using System.Text;

namespace ScheduleService.IoC.Container;

public class ConfigurationIoC
{
    public static void Configure(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddHttpContextAccessor();

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConn"));
            options.EnableDetailedErrors();
        });

        services.AddSingleton<IRedisClientsManagerAsync>(c => new RedisManagerPool(configuration.GetConnectionString("RedisConn")));
        _ = services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));

        IoCRepositories.AddInfrastructureRepository(services);
        IoCRepositoriesApplication.AddApplicationRepository(services);
        IoCHandlersApplication.AddApplicationHandler(services);

        ConfigureEncryptation(services, configuration);
        ConfigureJWT(services, configuration);
    }

    private static void ConfigureEncryptation(IServiceCollection services, ConfigurationManager configuration)
    {
        /* Encrypt Service */
        services.AddScoped<IEncryptionService, EncryptionService>();
        services.AddScoped<ITokenService, TokenService>();

        /* Encrypt Service Model */
        services.Configure<EncryptionModel>(configuration.GetSection("Encryption"));
    }

    private static void ConfigureJWT(IServiceCollection services, ConfigurationManager configuration)
    {
        /* JWT Authentication */
        services.Configure<JWTEncriptionModel>(configuration.GetSection("SecretToken"));
        string keySecretToken = configuration.GetSection("SecretToken")["Key"];
        services.AddAuthentication(x => JWTSchemes(x))
                .AddJwtBearer(x => JWTSetting(x, keySecretToken));

        static void JWTSetting(JwtBearerOptions x, string keySecretToken)
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(keySecretToken)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }

        static void JWTSchemes(AuthenticationOptions x)
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
