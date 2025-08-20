using oms_core.Errors;
using oms_core.Interface.Context;
using oms_core.Interface.Service;
using oms_core.Views;
using Stock;
using static Stock.StockService;

namespace oms_core.Service
{
    public sealed class StockService(IGrpcContext context) : IStockService
    {
        private readonly StockServiceClient _client = context.GetClient();

        public async Task<StockItemsPagedResult> ListStockItems(StockItemsPayload req)
        {
            ListStockItemRequest clientReq =
                new()
                {
                    Code = req.Code,
                    Name = req.Name,
                    GroupCode = req.GroupCode,
                    GroupName = req.GroupName,
                    PageNum = req.PageNum,
                    PageSize = req.PageSize,
                };

            StockItemResponse clientResponse = await _client.ListStockItemsAsync(clientReq);

            var response = new StockItemsPagedResult
            {
                TotalRecords = clientResponse.TotalRecords,
                Items =
                [
                    .. clientResponse.Items.Select(i => new StockItemsCollection
                    {
                        ItemCode = i.Code,
                        ItemName = i.Name,
                        Description = i.Description,
                    }),
                ],
            };

            return response;
        }

        public async Task<List<StockInquiryResponse>> CheckStockAvailability(
            List<StockActionRequest> req
        )
        {
            StockAvailabilityRequest clientReq = new();
            clientReq.Items.AddRange(
                req.Select(r => new StockItemRequest { Code = r.Code, Quantity = r.Quantity })
            );

            StockAvailabilityResponse clientResponse = await _client.CheckStockAvailabilityAsync(
                clientReq
            );

            var response = clientResponse
                .Items.Select(i => new StockInquiryResponse
                {
                    Available = i.Available,
                    AvailableQuantity = i.AvailableQuantity,
                    ItemCode = i.Code,
                    ItemName = i.Name,
                })
                .ToList();

            return response;
        }

        public async Task<List<StockConsumptionReport>> ConsumeStock(List<StockActionRequest> req)
        {
            ConsumeStockRequest clientReq = new();
            clientReq.Items.AddRange(
                req.Select(r => new StockItemRequest { Code = r.Code, Quantity = r.Quantity })
            );

            StockConsumptionResponse clientResponse = await _client.ConsumeStockAsync(clientReq);

            var response = clientResponse
                .Items.Select(i =>
                {
                    if (!i.Success)
                    {
                        throw new ValidationException($"{i.Code} - {i.Message}");
                    }

                    return new StockConsumptionReport
                    {
                        ItemCode = i.Code,
                        Message = i.Message,
                        Success = i.Success,
                    };
                })
                .ToList();

            return response;
        }
    }
}
