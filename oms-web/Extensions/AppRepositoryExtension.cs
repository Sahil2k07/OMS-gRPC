using oms_core.Interface.Repository;
using oms_core.Repository;

namespace oms_web.Extensions
{
    internal static class AppRepositoryExtension
    {
        internal static IServiceCollection AddAppRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
