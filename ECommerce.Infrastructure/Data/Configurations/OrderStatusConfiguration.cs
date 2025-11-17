using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(s => s.StatusID);

            builder.Property(s => s.StatusName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasMany(s => s.Orders)
                   .WithOne(o => o.Status)
                   .HasForeignKey(o => o.StatusID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("OrderStatus");
        }
    }
}
