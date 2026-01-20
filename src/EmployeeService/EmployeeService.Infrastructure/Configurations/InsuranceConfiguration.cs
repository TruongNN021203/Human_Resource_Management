using EmployeeService.Domain.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Configurations;

public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
{
    public void Configure(EntityTypeBuilder<Insurance> builder)
    {
        builder.ToTable("insurances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();

        builder.Property(x => x.InsuranceNumber)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.IssuedPlace)
               .IsRequired()
               .HasMaxLength(250);
        builder.Property(x => x.RegisteredHospital)
                     .IsRequired()
                     .HasMaxLength(250);
        builder.HasOne<Employee>()
                  .WithOne()
                  .HasForeignKey<Insurance>(e => e.EmployeeId)
                  .OnDelete(DeleteBehavior.Restrict);


        builder.HasIndex(x => x.PublicId).IsUnique();
    }
}