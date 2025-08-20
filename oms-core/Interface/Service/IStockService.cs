using oms_core.Views;

namespace oms_core.Interface.Service
{
    public interface IStockService
    {
        Task<StockItemsPagedResult> ListStockItems(StockItemsPayload req);

        Task<List<StockInquiryResponse>> CheckStockAvailability(List<StockActionRequest> req);

        Task<List<StockConsumptionReport>> ConsumeStock(List<StockActionRequest> req);
    }
}
