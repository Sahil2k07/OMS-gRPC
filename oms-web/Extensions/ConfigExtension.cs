using oms_core.Settings;

namespace oms_web.Extensions
{
    internal static class ConfigExtension
    {
        internal static IServiceCollection AddAppConfigs(
            this IServiceCollection services,
            IConfiguration configs
        )
        {
            var dbConfigs = configs.GetSection("DbSettings");
            var jwtSettingsSection = configs.GetSection("JwtSettings");
            var grpcSettingsSection = configs.GetSection("GrpcSettings");

            services.Configure<DbSettings>(dbConfigs);
            services.Configure<JwtSettings>(jwtSettingsSection);
            services.Configure<GrpcSettings>(grpcSettingsSection);

            return services;
        }
    }
}
