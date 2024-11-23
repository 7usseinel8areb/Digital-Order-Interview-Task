using DigitalOrder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOrder.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Type)
                .IsRequired();

            builder.Property(p => p.Details)
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired();

        }
    }
}
