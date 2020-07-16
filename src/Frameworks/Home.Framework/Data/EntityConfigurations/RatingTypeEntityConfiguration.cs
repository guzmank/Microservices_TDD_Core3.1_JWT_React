using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class RatingTypeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<RatingTypeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("RATING_TYPE");

            entity.Property(e => e.UniqueId)
                .HasColumnName("UniqueID")
                .ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
