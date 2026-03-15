using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Kernel.Common;

namespace AuthService.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.EmployeeCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Password)
            .HasMaxLength(255);

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.Gender)
            .HasMaxLength(10);

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.IdentityNumber)
            .HasMaxLength(50);

        builder.Property(x => x.AvatarUrl)
            .HasMaxLength(200);

        builder.Property(x => x.Status)
          .HasConversion<string>()
          .HasMaxLength(20)
          .IsRequired();

        builder.Property(x => x.Role)
               .HasConversion<string>()
               .HasMaxLength(20)
               .IsRequired();
        builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.EmployeeCode).IsUnique();
        builder.HasIndex(x => x.IdentityNumber).IsUnique();
    }
}