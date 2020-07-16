using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class SongEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<SongEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("SONG");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.SongPriceId).HasColumnName("SongPriceID");

            entity.Property(e => e.Time).HasColumnType("time(0)");

            entity.HasOne(d => d.Album)
                .WithMany(p => p.Song)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONG_ALBUM");

            entity.HasOne(d => d.SongPrice)
                .WithMany(p => p.Song)
                .HasForeignKey(d => d.SongPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONG_SONG_PRICE");
        }
    }
}
