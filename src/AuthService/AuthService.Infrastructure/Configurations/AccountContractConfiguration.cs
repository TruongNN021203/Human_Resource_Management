using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence.Configurations;

public class EmployeeDetailConfiguration : IEntityTypeConfiguration<AccountContract>
{
    public void Configure(EntityTypeBuilder<AccountContract> builder)
    {
        builder.ToTable("employee_details");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.PlaceOfBirth)
            .HasMaxLength(100);

        builder.Property(x => x.Hometown)
            .HasMaxLength(100);

        builder.Property(x => x.PermanentAddress)
            .HasMaxLength(255);

        builder.Property(x => x.TemporaryAddress)
            .HasMaxLength(255);

        builder.Property(x => x.Ethnicity)
            .HasMaxLength(50);

        builder.Property(x => x.Religion)
            .HasMaxLength(50);

        builder.Property(x => x.Nationality)
            .HasMaxLength(50);
        builder.Property(x => x.PublicId)
              .HasConversion(
                  v => v.ToString(),
                  v => Ulid.Parse(v))
              .HasMaxLength(26)
              .IsRequired();
        // Assuming a relationship with the Account entity
        builder.HasOne<AuthService.Domain.Entities.Account>()
            .WithMany()
            .HasForeignKey(d => d.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}