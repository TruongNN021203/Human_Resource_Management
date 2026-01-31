using AuthService.Domain.Entities;
using Domain.Aggregates.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence;

public class AccountContractConfiguration : IEntityTypeConfiguration<AccountContract>
{
    public void Configure(EntityTypeBuilder<AccountContract> builder)
    {
        builder.ToTable("account_contracts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.AccountId)
               .IsRequired();
               
        builder.Property(x => x.PublicId)
               .HasConversion(
                    v => v.ToString(),
                    v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();

        builder.Property(x => x.PlaceOfBirth)
               .HasMaxLength(255);

        builder.Property(x => x.Hometown)
               .HasMaxLength(255);

        builder.Property(x => x.PermanentAddress)
               .HasMaxLength(500);

        builder.Property(x => x.TemporaryAddress)
               .HasMaxLength(500);

        builder.Property(x => x.Ethnicity)
               .HasMaxLength(100);

        builder.Property(x => x.Religion)
               .HasMaxLength(100);

        builder.Property(x => x.Nationality)
               .HasMaxLength(100);

        builder.HasIndex(x => x.AccountId)
               .IsUnique();

        builder.HasOne<Account>()
               .WithOne()
               .HasForeignKey<AccountContract>(x => x.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
