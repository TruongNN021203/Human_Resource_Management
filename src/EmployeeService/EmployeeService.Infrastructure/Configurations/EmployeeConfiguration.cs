using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
       public void Configure(EntityTypeBuilder<Employee> builder)
       {
              builder.ToTable("employees");

              builder.HasKey(x => x.Id);

              builder.Property(x => x.Id)
                     .ValueGeneratedNever();

              builder.Property(x => x.PublicId)
                     .HasConversion(
                         v => v.ToString(),
                         v => Ulid.Parse(v))
                     .HasMaxLength(26)
                     .IsRequired();

              builder.Property(x => x.EmployeeCode)
                     .IsRequired()
                     .HasMaxLength(50);

              builder.Property(x => x.FullName)
                     .IsRequired()
                     .HasMaxLength(200);

              builder.Property(x => x.Email)
                     .IsRequired()
                     .HasMaxLength(150);
              builder.HasOne<Position>()
                     .WithMany()
                     .HasForeignKey(e => e.PositionId)
                     .OnDelete(DeleteBehavior.Restrict);
              builder.HasOne<EducationLevel>()
                     .WithMany()
                     .HasForeignKey(e => e.EducationLevelId)
                     .OnDelete(DeleteBehavior.Restrict);
              builder.HasOne<Department>()
                     .WithOne()
                     .HasForeignKey<Employee>(e => e.DepartmentId)
                     .OnDelete(DeleteBehavior.Restrict);
              builder
                .HasOne(e => e.SalaryGrade)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SalaryGradeId)
                .OnDelete(DeleteBehavior.Restrict);

              builder.HasIndex(x => x.Email).IsUnique();
              builder.HasIndex(x => x.PublicId).IsUnique();
       }

}
