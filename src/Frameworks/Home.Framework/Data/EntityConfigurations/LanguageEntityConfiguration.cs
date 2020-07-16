using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class LanguageEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<LanguageEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK__LANGUAGE__A2A2A54A798D135B");

            entity.ToTable("LANGUAGE");

            entity.HasIndex(e => e.Code)
                .HasName("UQ_LANGUAGE_Code")
                .IsUnique();

            entity.HasIndex(e => e.Name)
                .HasName("UQ_LANGUAGE_Name")
                .IsUnique();

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(6);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
