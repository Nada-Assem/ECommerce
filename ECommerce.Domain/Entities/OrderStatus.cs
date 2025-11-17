using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class OrderStatus
    {
        [Key]
        [Column("Status_ID")]
        public int StatusID { get; set; }

        [Column("Status_Name")]
        public string StatusName { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
