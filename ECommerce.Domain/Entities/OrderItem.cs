using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        [Column("OrderItem_ID")]
        public int OrderItemID { get; set; }

        [Column("Order_ID")]
        public int OrderID { get; set; }
        public Order? Order { get; set; }

        [Column("Product_ID")]
        public int ProductID { get; set; }
        public Product? Product { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; } = 1;

        [Column("Unit_Price", TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
    }
}
