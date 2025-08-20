using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using oms_core.Interface.Service;
using oms_core.Views;

namespace oms_web.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/v1/stock")]
    public sealed class StockController(IStockService stockService) : ControllerBase
    {
        private readonly IStockService _stockService = stockService;

        [HttpPost]
        public async Task<StockItemsPagedResult> ListStockItems(StockItemsPayload req)
        {
            return await _stockService.ListStockItems(req);
        }

        [HttpPost("enquire")]
        public async Task<List<StockInquiryResponse>> CheckStockAvailability(
            List<StockInquiryRequest> req
        )
        {
            return await _stockService.CheckStockAvailability(req);
        }
    }
}
