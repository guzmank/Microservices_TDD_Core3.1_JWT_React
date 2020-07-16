using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class RoleEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<RoleEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK__ROLE__A2A2A54AEB045052");

            entity.ToTable("ROLE");

            entity.HasIndex(e => e.Code)
                .HasName("UQ_ROLE_Code")
                .IsUnique();

            entity.HasIndex(e => e.Name)
                .HasName("UQ_ROLE_Name")
                .IsUnique();

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
