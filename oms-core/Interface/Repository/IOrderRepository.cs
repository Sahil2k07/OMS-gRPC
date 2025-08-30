using oms_core.Entity;
using oms_core.Views;

namespace oms_core.Interface.Repository
{
    public interface IOrderRepository
    {
        Task SaveOrder(Order order);

        Task SaveOrderItems(List<OrderItem> orderItems);

        Task<(int, List<OrderResponse>)> ListOrders(PaginatedRequest<ListOrdersRequest> req);
    }
}
