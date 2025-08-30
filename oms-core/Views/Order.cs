using System.ComponentModel.DataAnnotations;
using oms_core.Entity;
using oms_core.Enum;

namespace oms_core.Views
{
    public sealed class CreateOrderRequest
    {
        [Required]
        [StringLength(
            50,
            MinimumLength = 1,
            ErrorMessage = "Code must be between 1 and 50 characters."
        )]
        public required string ItemCode { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer.")]
        public required int Quantity { get; set; }
    }

    public sealed class ListOrdersRequest
    {
        public string? ProductCode { get; set; }

        public string? ProductName { get; set; }

        public OrderStatus? OrderStatus { get; set; }
    }

    public sealed class OrderItemResponse
    {
        public required string ProductCode { get; set; }

        public required string ProductName { get; set; }

        public required int Quantity { get; set; }
    }

    public sealed class OrderResponse
    {
        public required int OrderID { get; set; }

        public required OrderStatus OrderStatus { get; set; }

        public List<OrderItemResponse> OrderItems { get; set; } = [];

        public required Guid PrimaryIdentifier { get; set; }
    }
}
