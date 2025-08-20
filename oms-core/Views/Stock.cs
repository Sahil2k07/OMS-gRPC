using System.ComponentModel.DataAnnotations;

namespace oms_core.Views
{
    public sealed class StockItemsPayload
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? GroupCode { get; set; }

        public string? GroupName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "PageNum must be a positive integer.")]
        public required int PageNum { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "PageSize must be between 1 and 100.")]
        public required int PageSize { get; set; }
    }

    public sealed class StockActionRequest
    {
        [Required]
        [StringLength(
            50,
            MinimumLength = 1,
            ErrorMessage = "Code must be between 1 and 50 characters."
        )]
        public required string Code { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
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

    public sealed class StockConsumptionReport
    {
        public required string ItemCode { get; set; }

        public required bool Success { get; set; }

        public required string Message { get; set; }
    }
}
