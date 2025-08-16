using Microsoft.Extensions.Options;
using oms_core.Interface.Config;
using oms_core.Settings;

namespace oms_core.Config
{
    public sealed class DbDevConfig(IOptions<DbSettings> options) : IDbConfig
    {
        private readonly DbSettings _settings = options.Value;

        public string GetConnectionString()
        {
            return $"Server={_settings.Host};Database={_settings.Database};User Id={_settings.User};Password={_settings.Password};TrustServerCertificate=true";
        }
    }
}
