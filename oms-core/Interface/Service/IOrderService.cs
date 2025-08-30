using oms_core.Views;

namespace oms_core.Interface.Service
{
    public interface IOrderService
    {
        Task CreateOrder(List<CreateOrderRequest> req);

        Task<PaginatedResponse<OrderResponse>> ListOrders(PaginatedRequest<ListOrdersRequest> req);
    }
}
