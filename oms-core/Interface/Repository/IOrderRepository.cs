using oms_core.Entity;

namespace oms_core.Interface.Repository
{
    public interface IOrderRepository
    {
        Task SaveOrder(Order order);

        Task SaveOrderItems(List<OrderItem> orderItems);
    }
}
