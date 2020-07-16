using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class VersionHistoryEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<VersionHistoryEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("VERSION_HISTORY");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.LanguageUnique)
                .WithMany(p => p.VersionHistory)
                .HasForeignKey(d => d.LanguageUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERSION_HISTORY_LANGUAGE");

            entity.HasOne(d => d.SystemTypeUnique)
                .WithMany(p => p.VersionHistory)
                .HasForeignKey(d => d.SystemTypeUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VERSION_HISTORY_SYSTEM_TYPE");
        }
    }
}
