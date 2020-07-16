using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class AlbumPriceEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AlbumPriceEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("ALBUM_PRICE");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
        }
    }
}
