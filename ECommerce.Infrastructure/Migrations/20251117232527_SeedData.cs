using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Customer_ID", "Customer_Email", "Customer_Name", "Customer_Phone" },
                values: new object[,]
                {
                    { 1, "nada@example.com", "Nada Assem", "0123456789" },
                    { 2, "ali@example.com", "Ali Mohamed", "0112233445" },
                    { 3, "sara@example.com", "Sara Khaled", "0109988776" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Status_ID", "Status_Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Processing" },
                    { 3, "Completed" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product_ID", "Product_Description", "Product_Name", "Product_Price", "Stock" },
                values: new object[,]
                {
                    { 1, "High performance laptop", "Laptop", 15000m, 12 },
                    { 2, "Flagship smartphone", "Smartphone", 11000m, 30 },
                    { 3, "Noise canceling", "Wireless Headphones", 3200m, 45 },
                    { 4, "Water resistant", "Smartwatch", 2800m, 20 },
                    { 5, "Portable speaker", "Bluetooth Speaker", 1500m, 50 },
                    { 6, "RGB keyboard", "Gaming Keyboard", 900m, 35 },
                    { 7, "High DPI mouse", "Gaming Mouse", 700m, 40 },
                    { 8, "Android tablet", "Tablet 10 inch", 6000m, 18 },
                    { 9, "USB 3.0", "External Hard Disk 1TB", 1900m, 25 },
                    { 10, "4K UHD", "TV 55 inch", 18000m, 10 },
                    { 11, "High speed router", "Router WiFi 6", 2500m, 22 },
                    { 12, "Fast charging", "Power Bank 20000mAh", 800m, 60 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Customer_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Status_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Status_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Status_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatus",
                keyColumn: "Status_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Product_ID",
                keyValue: 12);
        }
    }
}
