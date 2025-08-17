using System.Security.Cryptography.X509Certificates;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using oms_core.Interface.Config;
using oms_core.Interface.Context;
using oms_core.Middleware;
using static Stock.StockService;

namespace oms_core.Context
{
    public sealed class GrpcContext : IGrpcContext
    {
        private readonly IGrpcConfig _config;
        private readonly StockServiceClient _client;

        public GrpcContext(IGrpcConfig config)
        {
            _config = config;
            _client = GenerateStockClient(config);
        }

        private static StockServiceClient GenerateStockClient(IGrpcConfig config)
        {
            string? address = config.GetClientAddress();
            string? certPath = config.GetCertificatePath();
            string? apiToken = config.GetApiToken();

            if (string.IsNullOrEmpty(address))
            {
                throw new InvalidOperationException("Grpc stock client address not available");
            }

            if (string.IsNullOrEmpty(apiToken))
            {
                throw new InvalidOperationException("Token missing for Grpc stock client");
            }

            var handler = new HttpClientHandler();
            if (!string.IsNullOrEmpty(certPath))
            {
                var cert = new X509Certificate2(certPath);
                handler.ClientCertificates.Add(cert);
            }

            var channel = GrpcChannel.ForAddress(
                address,
                new GrpcChannelOptions { HttpHandler = handler }
            );
            var invoker = channel.Intercept(new StockInterceptor(apiToken));

            return new StockServiceClient(invoker);
        }

        public StockServiceClient GetClient() => _client;

        public CallOptions GetCallOptions()
        {
            string? apiToken = _config.GetApiToken();
            if (string.IsNullOrEmpty(apiToken))
                return new CallOptions();

            var headers = new Metadata { { "Authorization", $"Bearer {apiToken}" } };
            return new CallOptions(headers);
        }
    }
}
