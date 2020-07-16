using Home.Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home.Framework.Data.EntityConfigurations
{
    public static class DepartmentEmployeeEntityConfiguration
    {
        public static void Configure(EntityTypeBuilder<DepartmentEmployeeEntity> entity)
        {
            entity.HasKey(e => e.UniqueId);

            entity.ToTable("DEPARTMENT_EMPLOYEE");

            entity.Property(e => e.UniqueId).ValueGeneratedNever();

            entity.HasOne(d => d.DepartmentUnique)
                .WithMany(p => p.DepartmentEmployee)
                .HasForeignKey(d => d.DepartmentUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEPARTMENT_EMPLOYEE_DEPARTMENT");

            entity.HasOne(d => d.EmployeeUnique)
                .WithMany(p => p.DepartmentEmployee)
                .HasForeignKey(d => d.EmployeeUniqueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DEPARTMENT_EMPLOYEE_EMPLOYEE");
        }
    }
}
