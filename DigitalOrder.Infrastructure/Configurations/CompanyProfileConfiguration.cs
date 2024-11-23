using DigitalOrder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOrder.Infrastructure.Configurations
{
    internal class CompanyProfileConfiguration : IEntityTypeConfiguration<CompanyProfile>
    {
        public void Configure(EntityTypeBuilder<CompanyProfile> builder)
        {
            builder.Property(cp => cp.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(cp => cp.Description)
                .HasMaxLength(500);

            builder.Property(cp => cp.Mission)
                .HasMaxLength(500);

            builder.Property(cp => cp.Vision)
                .HasMaxLength(500);

            builder.HasMany(cp => cp.CoreValues)
                .WithOne(cv => cv.CompanyProfile)
                .HasForeignKey(cv => cv.CompanyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
