namespace oms_core.Views
{
    public sealed class StockItemsPayload
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? GroupCode { get; set; }

        public string? GroupName { get; set; }

        public required int PageNum { get; set; }

        public required int PageSize { get; set; }
    }

    public sealed class StockInquiryRequest
    {
        public required string Code { get; set; }

        public required int Quantity { get; set; }
    }

    public sealed class StockItemsCollection
    {
        public required string ItemCode { get; set; }

        public required string ItemName { get; set; }

        public required string Description { get; set; }
    }

    public sealed class StockItemsPagedResult
    {
        public required long TotalRecords { get; set; }

        public List<StockItemsCollection> Items { get; set; } = [];
    }

    public sealed class StockInquiryResponse
    {
        public required string ItemCode { get; set; }

        public required string ItemName { get; set; }

        public required bool Available { get; set; }

        public float? AvailableQuantity { get; set; }
    }
}
