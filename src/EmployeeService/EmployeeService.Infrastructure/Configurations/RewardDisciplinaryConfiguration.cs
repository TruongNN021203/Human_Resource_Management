using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class RewardDisciplinaryConfiguration : IEntityTypeConfiguration<RewardDisciplinary>
{
    public void Configure(EntityTypeBuilder<RewardDisciplinary> builder)
    {
        builder.ToTable("rewards_disciplinary");

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


        builder.Property(x => x.DecisionNumber)
               .HasMaxLength(100);

        builder.Property(x => x.Content)
               .HasColumnType("text");

        builder.Property(x => x.EffectiveDate)
               .IsRequired();

        builder.HasIndex(x => x.PublicId).IsUnique();

        builder.HasOne<Employee>()
               .WithMany()
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
