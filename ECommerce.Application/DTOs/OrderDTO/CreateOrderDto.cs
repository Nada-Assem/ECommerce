using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.OrderDTO
{
    public class CreateOrderDto
    {
        public int CustomerID { get; set; }
        public List<OrderProductDto> Products { get; set; } = new();

    }


}
