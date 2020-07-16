using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class SongPriceEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<SongPriceEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("SONG_PRICE");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
        }
    }
}
