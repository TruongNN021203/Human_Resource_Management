using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class AllowanceConfiguration : IEntityTypeConfiguration<Allowance>
{
    public void Configure(EntityTypeBuilder<Allowance> builder)
    {
        builder.ToTable("allowances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();

        builder.Property(x => x.EmployeeId)
               .IsRequired();

        builder.Property(x => x.Name)
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(x => x.Amount)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(x => x.ReceivedDate)
               .IsRequired();

        builder.HasIndex(x => x.PublicId).IsUnique();

        builder.HasOne<Employee>()
               .WithMany()
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
