using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class CompanyEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<CompanyEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("COMPANY");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Address1)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Address2)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.CountryCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.OrganizationNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
