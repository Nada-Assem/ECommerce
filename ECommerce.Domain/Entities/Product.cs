using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        [Key]
        [Column("Product_ID")]
        public int ProductID { get; set; }

        [Column("Product_Name")]
        public string ProductName { get; set; } = null!;

        [Column("Product_Description")]
        public string? ProductDescription { get; set; }

        [Column("Product_Price", TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        public int Stock { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
