using System.ComponentModel.DataAnnotations;

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
}
