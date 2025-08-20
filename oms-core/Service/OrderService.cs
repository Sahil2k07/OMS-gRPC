using oms_core.Interface.Repository;
using oms_core.Interface.Service;

namespace oms_core.Service
{
    public sealed class OrderService(IStockService stockService, IOrderRepository orderRepository)
        : IOrderService
    {
        private readonly IStockService _stockService = stockService;

        private readonly IOrderRepository _orderRepository = orderRepository;
    }
}
