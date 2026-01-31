using Domain.Aggregates.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthService.Infrastructure.Persistence;

public class AccountTokenConfiguration : IEntityTypeConfiguration<AccountToken>
{
    public void Configure(EntityTypeBuilder<AccountToken> builder)
    {
        builder.ToTable("account_tokens");
 
         builder.Property(x => x.PublicId)
               .HasConversion(
                   v => v.ToString(),
                   v => Ulid.Parse(v))
               .HasMaxLength(26)
               .IsRequired();
               
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.Token)
               .HasMaxLength(512)
               .IsRequired(false);

        builder.Property(x => x.ClientIp)
               .HasMaxLength(45); // IPv6 max length

        builder.Property(x => x.FamilyId)
               .HasMaxLength(100);

        builder.Property(x => x.ExpiredTime)
               .IsRequired();

        builder.Property(x => x.AccountId)
               .IsRequired();

        builder.HasIndex(x => x.Token)
               .IsUnique();

        builder.HasOne(x => x.Account)
               .WithMany()
               .HasForeignKey(x => x.AccountId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
