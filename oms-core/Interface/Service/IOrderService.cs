using oms_core.Views;

namespace oms_core.Interface.Service
{
    public interface IOrderService
    {
        Task CreateOrder(List<CreateOrderRequest> req);
    }
}
