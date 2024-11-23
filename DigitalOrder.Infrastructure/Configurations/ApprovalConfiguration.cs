using DigitalOrder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOrder.Infrastructure.Configurations
{
    internal class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Authority)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.IssuedDate)
                .IsRequired();

            builder.Property(a => a.ExpiryDate)
                .IsRequired(false);
        }
    }
}
