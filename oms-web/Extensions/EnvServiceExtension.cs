using oms_core.Config;
using oms_core.Interface.Config;

namespace oms_web.Extensions
{
    internal static class EnvServiceExtension
    {
        internal static IServiceCollection AddEnvServices(
            this IServiceCollection services,
            IHostEnvironment env
        )
        {
            if (env.IsDevelopment())
            {
                services.AddSingleton<IDbConfig, DbDevConfig>();
                services.AddSingleton<IGrpcConfig, GrpcDevConfig>();
            }
            else
            {
                services.AddSingleton<IDbConfig, DbProdConfig>();
                services.AddSingleton<IGrpcConfig, GrpcProdConfig>();
            }

            return services;
        }
    }
}
