using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.OrderDTO
{
    public class OrderProductDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
