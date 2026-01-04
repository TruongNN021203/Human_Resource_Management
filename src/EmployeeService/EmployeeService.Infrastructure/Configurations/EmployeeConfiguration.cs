using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Kernel.Common;

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

              builder.Property(x => x.Code)
                     .IsRequired()
                     .HasMaxLength(50);

              builder.Property(x => x.FullName)
                     .IsRequired()
                     .HasMaxLength(200);

              builder.Property(x => x.Email)
                     .IsRequired()
                     .HasMaxLength(150);

              builder.HasIndex(x => x.Email).IsUnique();
              builder.HasIndex(x => x.PublicId).IsUnique();
       }

}
