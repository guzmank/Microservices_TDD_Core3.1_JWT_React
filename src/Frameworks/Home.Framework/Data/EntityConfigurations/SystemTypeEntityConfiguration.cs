using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class SystemTypeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<SystemTypeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("SYSTEM_TYPE");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
