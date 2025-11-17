using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Order
    {
        [Key]
        [Column("Order_ID")]
        public int OrderID { get; set; }

        [Column("Customer_ID")]
        public int CustomerID { get; set; }

        public Customer? Customer { get; set; }

        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }

        [Column("Status_ID")]
        public int StatusID { get; set; }

        public OrderStatus? Status { get; set; }

        [Column("Total_Price", TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
