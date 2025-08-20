using oms_core.Views;

namespace oms_core.Interface.Service
{
    public interface IStockService
    {
        Task<StockItemsPagedResult> ListStockItems(StockItemsPayload req);

        Task<List<StockInquiryResponse>> CheckStockAvailability(List<StockInquiryRequest> req);
    }
}
