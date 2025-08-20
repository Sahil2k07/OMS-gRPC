using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oms_core.Interface.Service;

namespace oms_web.Controller
{
    [ApiController]
    [Authorize]
    [Route("/api/v1/order")]
    public sealed class OrderController(IOrderService orderService)
    {
        private readonly IOrderService _orderService = orderService;
    }
}
