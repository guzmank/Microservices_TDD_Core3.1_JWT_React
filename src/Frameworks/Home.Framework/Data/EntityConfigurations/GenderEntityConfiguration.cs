using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class GenderEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<GenderEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK__GENDER");

            entity.ToTable("GENDER");

            entity.HasIndex(e => e.Name)
                .HasName("UQ_GENDER_Name")
                .IsUnique();

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
