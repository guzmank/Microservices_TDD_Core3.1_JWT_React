using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class MusicTypeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<MusicTypeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("MUSIC_TYPE");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
