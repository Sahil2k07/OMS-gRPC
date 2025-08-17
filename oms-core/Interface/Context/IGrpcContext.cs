using Grpc.Core;
using static Stock.StockService;

namespace oms_core.Interface.Context
{
    public interface IGrpcContext
    {
        StockServiceClient GetClient();

        CallOptions GetCallOptions();
    }
}
