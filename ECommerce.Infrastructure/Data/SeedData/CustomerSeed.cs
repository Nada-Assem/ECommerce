using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seed
{
    public static class CustomerSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, CustomerName = "Nada Assem", CustomerEmail = "nada@example.com", CustomerPhone = "0123456789" },
                new Customer { CustomerID = 2, CustomerName = "Ali Mohamed", CustomerEmail = "ali@example.com", CustomerPhone = "0112233445" },
                new Customer { CustomerID = 3, CustomerName = "Sara Khaled", CustomerEmail = "sara@example.com", CustomerPhone = "0109988776" }
            );
        }
    }
}
