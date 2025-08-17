using Grpc.Core;
using Grpc.Core.Interceptors;

namespace oms_core.Middleware
{
    public sealed class StockInterceptor(string apiToken) : Interceptor
    {
        private readonly string _apiToken = apiToken;

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation
        )
        {
            var headers = context.Options.Headers ?? [];
            headers.Add("Authorization", $"Bearer {_apiToken}");

            var options = context.Options.WithHeaders(headers);
            var newContext = new ClientInterceptorContext<TRequest, TResponse>(
                context.Method,
                context.Host,
                options
            );

            return continuation(request, newContext);
        }
    }
}
