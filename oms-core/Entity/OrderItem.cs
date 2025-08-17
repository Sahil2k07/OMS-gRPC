using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oms_core.Entity
{
    [Table("ORDER_ITEM")]
    public sealed class OrderItem
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Order))]
        public required int OrderID { get; set; }

        public Order? Order { get; set; }

        public required string ProductCode { get; set; }

        public required string ProductName { get; set; }

        public required decimal Quantity { get; set; }

        public Guid PrimaryIdentifier { get; set; } = Guid.NewGuid();
    }
}
