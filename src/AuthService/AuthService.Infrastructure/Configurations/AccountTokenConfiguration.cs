using AuthService.Domain.Entities;
using Domain.Aggregates.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence.Configurations;

public class AccountTokenConfiguration : IEntityTypeConfiguration<AccountToken>
{
    public void Configure(EntityTypeBuilder<AccountToken> builder)
    {
        builder.ToTable("account_tokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Token)
            .HasMaxLength(500);

        builder.Property(x => x.ClientIp)
            .HasMaxLength(50);

        builder.Property(x => x.FamilyId)
            .HasMaxLength(50);

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.ExpiredTime)
            .IsRequired();
        builder.Property(x => x.PublicId)
              .HasConversion(
                  v => v.ToString(),
                  v => Ulid.Parse(v))
              .HasMaxLength(26)
              .IsRequired();
        builder.HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Cascade); // Assuming if an account is deleted, its tokens are also deleted
    }
}
