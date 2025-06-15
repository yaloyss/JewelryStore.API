using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStore.DAL.Models.Configuration
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Weight)
                .IsRequired()
                .HasColumnType("decimal(10,2)"); 

            builder.Property(p => p.Metal)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(p => p.Stone)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(p => p.Size)
                .IsRequired(false)
                .HasColumnType("decimal(8,2)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(12,2)"); 

            builder.Property(p => p.Manufacturer)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}

