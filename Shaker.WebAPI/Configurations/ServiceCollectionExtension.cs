using Shaker.Application.Services;
using Shaker.Domain.UnitOfWork;
using Shaker.Persistance.Mapping;
using Shaker.Persistance.Services;
using Shaker.Persistance.UnitOfWorks;

namespace Shaker.WebAPI.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServiceConfigurations(this IServiceCollection services)
    {
        #region AppScopes
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        #endregion

        #region Utilities
        services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        #endregion

        return services;
    }
}
