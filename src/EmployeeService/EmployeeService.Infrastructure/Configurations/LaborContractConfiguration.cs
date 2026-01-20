using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class LaborContractConfiguration : IEntityTypeConfiguration<LaborContract>
{
    public void Configure(EntityTypeBuilder<LaborContract> builder)
    {
        builder.ToTable("labor_contracts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();

        builder.Property(x => x.ContractNumber)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.EmployeeId)
               .IsRequired();

        builder.Property(x => x.SignedDate)
               .IsRequired();

        builder.Property(x => x.StartDate)
               .IsRequired();

        builder.Property(x => x.EndDate);

        builder.Property(x => x.Content)
               .HasColumnType("text");

        builder.Property(x => x.SalaryCoefficient)
               .IsRequired();

        builder.HasIndex(x => x.PublicId).IsUnique();
        builder.HasIndex(x => x.ContractNumber).IsUnique();

        builder.HasOne<Employee>()
               .WithMany()
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
