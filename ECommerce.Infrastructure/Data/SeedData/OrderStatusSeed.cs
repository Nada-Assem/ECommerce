using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seed
{
    public static class OrderStatusSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { StatusID = 1, StatusName = "Pending" },
                new OrderStatus { StatusID = 2, StatusName = "Processing" },
                new OrderStatus { StatusID = 3, StatusName = "Completed" },
                new OrderStatus { StatusID = 4, StatusName = "Cancelled" }
            );
        }
    }
}
