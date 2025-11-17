using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Customer
    {
        [Key]
        [Column("Customer_ID")]
        public int CustomerID { get; set; }

        [Column("Customer_Name")]
        public string CustomerName { get; set; }

        [Column("Customer_Email")]
        public string CustomerEmail { get; set; }

        [Column("Customer_Phone")]
        public string? CustomerPhone { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
