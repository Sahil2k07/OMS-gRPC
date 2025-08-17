using Microsoft.Extensions.Options;
using oms_core.Interface.Config;
using oms_core.Settings;

namespace oms_core.Config
{
    public sealed class GrpcProdConfig : IGrpcConfig
    {
        public string? GetApiToken() => Environment.GetEnvironmentVariable("STOCK_SERVICE_TOKEN");

        public string GetCertificatePath() =>
            Path.Combine(AppContext.BaseDirectory, "certs", "stock.crt");

        public string? GetClientAddress() =>
            Environment.GetEnvironmentVariable("STOCK_SERVICE_ADDRESS");
    }

    public sealed class GrpcDevConfig(IOptions<GrpcSettings> options) : IGrpcConfig
    {
        private readonly GrpcSettings _settings = options.Value;

        public string? GetApiToken() => _settings.ServiceToken;

        public string GetCertificatePath() =>
            Path.Combine(AppContext.BaseDirectory, "certs", "stock.crt");

        public string? GetClientAddress() => _settings.ServiceAddress;
    }
}
