using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class UserRoleEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<UserRoleEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("USER_ROLE");

            entity.HasIndex(e => new { e.UserUniqueId, e.RoleUniqueId })
                .HasName("IX_USER_ROLE")
                .IsUnique();

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.HasOne(d => d.RoleUnique)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.RoleUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Role_User");

            entity.HasOne(d => d.UserUnique)
                .WithMany(p => p.UserRole)
                .HasForeignKey(d => d.UserUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        }
    }
}
