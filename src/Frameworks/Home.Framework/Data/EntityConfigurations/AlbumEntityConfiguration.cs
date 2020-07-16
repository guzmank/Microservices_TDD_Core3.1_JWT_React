using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class AlbumEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AlbumEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);
            
            entity.ToTable("ALBUM");
            
            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.AlbumPriceId).HasColumnName("AlbumPriceID");

            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

            entity.Property(e => e.CopyRightInfo).HasMaxLength(500);

            entity.Property(e => e.CoverPath).HasMaxLength(1000);

            entity.Property(e => e.MusicTypeId).HasColumnName("MusicTypeID");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Released).HasColumnType("datetime");

            entity.HasOne(d => d.AlbumPrice)
                .WithMany(p => p.Album)
                .HasForeignKey(d => d.AlbumPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUM_ALBUM_PRICE");

            entity.HasOne(d => d.Artist)
                .WithMany(p => p.Album)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUM_ARTIST");

            entity.HasOne(d => d.MusicType)
                .WithMany(p => p.Album)
                .HasForeignKey(d => d.MusicTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUM_MUSIC_TYPE");
        }
    }
}
