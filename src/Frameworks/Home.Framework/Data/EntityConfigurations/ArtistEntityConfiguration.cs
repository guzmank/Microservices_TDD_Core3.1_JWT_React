using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class ArtistEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<ArtistEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("ARTIST");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
