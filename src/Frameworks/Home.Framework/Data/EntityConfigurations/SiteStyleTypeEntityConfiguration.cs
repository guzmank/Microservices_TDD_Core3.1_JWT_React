using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class SiteStyleTypeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<SiteStyleTypeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK_SITE_STYLE");

            entity.ToTable("SITE_STYLE_TYPE");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
