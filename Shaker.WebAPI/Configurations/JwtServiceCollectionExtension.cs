using Shaker.Application.Services.Utilities;
using Shaker.Infrastructure.Jwt;

namespace Shaker.WebAPI.Configurations;

public static class JwtServiceCollectionExtension
{
     public static IServiceCollection JwtServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
