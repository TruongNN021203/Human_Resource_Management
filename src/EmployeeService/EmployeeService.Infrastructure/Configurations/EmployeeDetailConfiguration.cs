    using EmployeeService.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    namespace EmployeeService.Infrastructure.Persistence.Configurations;

    public class EmployeeDetailConfiguration : IEntityTypeConfiguration<EmployeeDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeDetail> builder)
        {

            builder.ToTable("employee_details");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.PublicId)
                .HasConversion(
                    v => v.ToString(),
                    v => Ulid.Parse(v))
                .HasMaxLength(26)
                .IsRequired();

            builder.Property(x => x.PlaceOfBirth)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Hometown)
            .IsRequired()
            .HasMaxLength(250);

            builder.Property(x => x.PermanentAddress)
            .IsRequired()
            .HasMaxLength(250);

            builder.Property(x => x.TemporaryAddress)
            .IsRequired()
            .HasMaxLength(250);

            builder.Property(x => x.Ethnicity)
            .IsRequired()
            .HasMaxLength(250);

            builder.Property(x => x.Religion)
            .IsRequired()
            .HasMaxLength(250);

            builder.Property(x => x.Nationality)
            .IsRequired()
            .HasMaxLength(250);

            builder.HasIndex(x => x.PublicId).IsUnique();

            builder.HasOne<Employee>()
                .WithOne()
                .HasForeignKey<EmployeeDetail>(ed => ed.EmployeeId)
                .IsRequired();

        }
    }