using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStore.DAL.Models.Configuration
{
	public class PositionConfiguration : IEntityTypeConfiguration<Position>
	{
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.PositionId);

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}

