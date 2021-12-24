using EasyValidation.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ScheduleService.Application.Handler.Handlers;
using ScheduleService.Application.Handler.Services;
using ScheduleService.Application.Handler.Services.Models;
using ScheduleService.Application.Validator.Validators.Cities;
using ScheduleService.Infrastructure.Context.Contexts;
using System.Text;

namespace ScheduleService.IoC.Container;

public class ConfigurationIoC
{
    public static void Configure(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration;

        services.AddHttpContextAccessor();

        services.AddDbContext<ScheduleServiceDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DbConn"));
            options.EnableDetailedErrors();
        });

        IoCRepositories.Configure(services, configuration);

        services.AddEasyValidationValidators(typeof(CityCreateValidator).Assembly);
        services.AddMediatR(typeof(IHandlerBus).Assembly);

        /* Handler Bus */
        services.AddScoped<IHandlerBus, HandlerBus>();

        /* Encrypt Service */
        services.AddScoped<IEncryptionService, EncryptionService>();
        services.AddScoped<ITokenService, TokenService>();

        /* Encrypt Service Model */
        services.Configure<EncryptionModel>(configuration.GetSection("Encryption"));

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
