using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.CustomerEmail)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(c => c.CustomerEmail).IsUnique();

            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Customers");
        }
    }
}
