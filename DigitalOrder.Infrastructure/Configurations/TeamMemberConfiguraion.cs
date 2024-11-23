using DigitalOrder.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalOrder.Infrastructure.Configurations
{
    internal class TeamMemberConfiguraion : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.Property(tm => tm.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(tm => tm.Role)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(tm => tm.Phone)
                .HasMaxLength(20);

            builder.Property(tm => tm.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(tm => tm.Expertise)
                .HasMaxLength(200);
        }
    }
}
