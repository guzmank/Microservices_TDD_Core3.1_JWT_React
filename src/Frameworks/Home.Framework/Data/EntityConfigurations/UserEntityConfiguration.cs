using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class UserEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<UserEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK__USER__A2A2A54A966542D1");

            entity.ToTable("USER");

            entity.HasIndex(e => e.Username)
                .HasName("UQ_USER_Login")
                .IsUnique();

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Token).HasMaxLength(500);

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
