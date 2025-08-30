using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oms_core.Interface.Service;
using oms_core.Views;

namespace oms_web.Controller
{
    [ApiController]
    [Authorize]
    [Route("/api/v1/order")]
    public sealed class OrderController(IOrderService orderService)
    {
        private readonly IOrderService _orderService = orderService;

        [HttpPost]
        public async Task CreateOrder([FromBody] List<CreateOrderRequest> req)
        {
            await _orderService.CreateOrder(req);
        }

        [HttpPost("list")]
        public async Task<PaginatedResponse<OrderResponse>> ListOrders(
            PaginatedRequest<ListOrdersRequest> req
        )
        {
            return await _orderService.ListOrders(req);
        }
    }
}
