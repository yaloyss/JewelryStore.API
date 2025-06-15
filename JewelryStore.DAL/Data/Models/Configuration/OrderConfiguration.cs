using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStore.DAL.Models.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Employee)
                .WithMany()
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

