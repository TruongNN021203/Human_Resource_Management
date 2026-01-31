using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();

        builder.Property(x => x.DepartmentName)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.Code)
               .HasMaxLength(50);

        builder.Property(x => x.Phone)
               .HasMaxLength(20);

        builder.Property(x => x.Address)
               .HasMaxLength(255);

        builder.Property(x => x.Note)
               .HasColumnType("text");

        builder.Property(x => x.ParentId);

        builder.HasIndex(x => x.PublicId).IsUnique();
        builder.HasIndex(x => x.Code).IsUnique();

        builder.HasOne<Department>()
               .WithMany()
               .HasForeignKey(x => x.ParentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
