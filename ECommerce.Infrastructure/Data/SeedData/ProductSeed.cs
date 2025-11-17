using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Data.Seed
{
    public static class ProductSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product { ProductID = 1, ProductName = "Laptop", ProductDescription = "High performance laptop", ProductPrice = 15000m, Stock = 12 },
               new Product { ProductID = 2, ProductName = "Smartphone", ProductDescription = "Flagship smartphone", ProductPrice = 11000m, Stock = 30 },
               new Product { ProductID = 3, ProductName = "Wireless Headphones", ProductDescription = "Noise canceling", ProductPrice = 3200m, Stock = 45 },
               new Product { ProductID = 4, ProductName = "Smartwatch", ProductDescription = "Water resistant", ProductPrice = 2800m, Stock = 20 },
               new Product { ProductID = 5, ProductName = "Bluetooth Speaker", ProductDescription = "Portable speaker", ProductPrice = 1500m, Stock = 50 },
               new Product { ProductID = 6, ProductName = "Gaming Keyboard", ProductDescription = "RGB keyboard", ProductPrice = 900m, Stock = 35 },
               new Product { ProductID = 7, ProductName = "Gaming Mouse", ProductDescription = "High DPI mouse", ProductPrice = 700m, Stock = 40 },
               new Product { ProductID = 8, ProductName = "Tablet 10 inch", ProductDescription = "Android tablet", ProductPrice = 6000m, Stock = 18 },
               new Product { ProductID = 9, ProductName = "External Hard Disk 1TB", ProductDescription = "USB 3.0", ProductPrice = 1900m, Stock = 25 },
               new Product { ProductID = 10, ProductName = "TV 55 inch", ProductDescription = "4K UHD", ProductPrice = 18000m, Stock = 10 },
               new Product { ProductID = 11, ProductName = "Router WiFi 6", ProductDescription = "High speed router", ProductPrice = 2500m, Stock = 22 },
               new Product { ProductID = 12, ProductName = "Power Bank 20000mAh", ProductDescription = "Fast charging", ProductPrice = 800m, Stock = 60 }
           );
        }
    }
}
