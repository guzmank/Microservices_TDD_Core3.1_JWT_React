using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class AlbumRatingEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<AlbumRatingEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("ALBUM_RATING");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

            entity.Property(e => e.RatingTypeId).HasColumnName("RatingTypeID");

            entity.HasOne(d => d.Album)
                .WithMany(p => p.AlbumRating)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUM_RATING_ALBUM");

            entity.HasOne(d => d.RatingType)
                .WithMany(p => p.AlbumRating)
                .HasForeignKey(d => d.RatingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALBUM_RATING_RATING_TYPE");
        }
    }
}
