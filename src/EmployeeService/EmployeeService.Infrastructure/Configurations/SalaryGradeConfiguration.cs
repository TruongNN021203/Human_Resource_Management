using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class SalaryGradeConfiguration : IEntityTypeConfiguration<SalaryGrade>
{
       public void Configure(EntityTypeBuilder<SalaryGrade> builder)
       {
              builder.ToTable("salary_grades");

              builder.HasKey(x => x.Id);

              builder.Property(x => x.Id)
                     .ValueGeneratedNever();

              builder.Property(x => x.PublicId)
                     .HasConversion(
                         v => v.ToString(),
                         v => Ulid.Parse(v))
                     .HasMaxLength(26)
                     .IsRequired();

              builder.Property(x => x.Code)
                     .HasMaxLength(50)
                     .IsRequired();

              builder.Property(x => x.Name)
                     .HasMaxLength(255)
                     .IsRequired();

              builder.Property(x => x.BaseSalary)
                     .HasColumnType("decimal(18,2)")
                     .IsRequired();
            
              builder.HasIndex(x => x.PublicId)
                     .IsUnique();

              builder.HasIndex(x => x.Code)
                     .IsUnique();
       }
}
