using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using oms_core.Enum;

namespace oms_core.Entity
{
    [Table("ORDER")]
    public sealed class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public required string CreatedBy { get; set; }

        [Required]
        public required int CreatedByID { get; set; }

        [Required]
        public required OrderStatus Status { get; set; }

        [Required]
        public Guid PrimaryIdentifier { get; set; } = Guid.NewGuid();

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
