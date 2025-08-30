using oms_core.Entity;
using oms_core.Enum;
using oms_core.Errors;
using oms_core.Interface.Repository;
using oms_core.Interface.Service;
using oms_core.Views;

namespace oms_core.Service
{
    public sealed class OrderService(
        IStockService stockService,
        IOrderRepository orderRepository,
        IAuthService authService
    ) : IOrderService
    {
        private readonly IStockService _stockService = stockService;

        private readonly IOrderRepository _orderRepository = orderRepository;

        private readonly IAuthService _authService = authService;

        public async Task CreateOrder(List<CreateOrderRequest> req)
        {
            // Check Availability first
            var payloads = req.Select(r => new StockActionRequest
                {
                    Code = r.ItemCode,
                    Quantity = r.Quantity,
                })
                .ToList();

            List<StockInquiryResponse>? inquiryResponse =
                await _stockService.CheckStockAvailability(payloads);

            if (inquiryResponse.Any(r => r.Available == false))
            {
                throw new ValidationException("Some items are not available right now");
            }

            // Make the order
            User user = await _authService.GetUser();

            var order = new Order
            {
                CreatedByID = user.ID,
                CreatedBy = user.Email,
                Status = OrderStatus.QUOTE,
            };

            await _orderRepository.SaveOrder(order);

            // Make the Order-Items
            var orderItems = inquiryResponse
                .Select(r => new OrderItem
                {
                    OrderID = order.ID,
                    ProductCode = r.ItemCode,
                    ProductName = r.ItemName,
                    Quantity = payloads
                        .Where(p => p.Code == r.ItemCode)
                        .Select(p => p.Quantity)
                        .FirstOrDefault(),
                })
                .ToList();

            await _orderRepository.SaveOrderItems(orderItems);

            await _stockService.ConsumeStock(payloads);
        }
    }
}
