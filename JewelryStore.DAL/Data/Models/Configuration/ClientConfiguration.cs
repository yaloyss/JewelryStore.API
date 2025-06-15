using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JewelryStore.DAL.Models.Configuration
{
	public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.BirthDate)
                .IsRequired(false);
        }
    }
}

