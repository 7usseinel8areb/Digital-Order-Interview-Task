using DigitalOrder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOrder.Infrastructure.Configurations
{
    internal class CoreValueConfiguration : IEntityTypeConfiguration<CoreValue>
    {
        public void Configure(EntityTypeBuilder<CoreValue> builder)
        {
            builder.Property(cv => cv.Value)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
