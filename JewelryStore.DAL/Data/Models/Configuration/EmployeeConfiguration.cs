using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStore.DAL.Models.Configuration
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.BirthDate)
                .IsRequired(false);

            builder.Property(e => e.Schedule)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

