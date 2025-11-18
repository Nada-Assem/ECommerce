using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.OrderDTO
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; } 
        public string Status { get; set; } 
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }

    }

}
