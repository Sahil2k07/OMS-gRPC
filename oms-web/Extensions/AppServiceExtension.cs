using oms_core.Interface.Service;
using oms_core.Service;

namespace oms_web.Extensions
{
    internal static class AppServiceExtension
    {
        internal static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
