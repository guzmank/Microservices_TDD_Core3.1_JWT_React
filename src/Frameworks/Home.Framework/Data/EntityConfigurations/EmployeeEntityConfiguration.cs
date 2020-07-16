using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class EmployeeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<EmployeeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId)
                    .HasName("PK__CUSTOMER__A2A2A54AF97F42A1");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.Property(e => e.BirthDate).HasColumnType("datetime");

            entity.Property(e => e.EmployeeNumber).HasMaxLength(50);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.IdCard).HasMaxLength(20);

            entity.Property(e => e.Initials).HasMaxLength(10);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Mobil).HasMaxLength(50);

            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.GenderUnique)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.GenderUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLOYEE_GENDER");

            entity.HasOne(d => d.LanguageUnique)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.LanguageUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLOYEE_LANGUAGE");

            entity.HasOne(d => d.SiteStyleTypeUnique)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.SiteStyleTypeUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLOYEE_SITE_STYLE_TYPE");

            entity.HasOne(d => d.UserUnique)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.UserUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EMPLOYEE_USER");
        }
    }
}
