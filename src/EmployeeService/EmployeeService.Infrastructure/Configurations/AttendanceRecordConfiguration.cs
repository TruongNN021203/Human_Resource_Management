using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeService.Infrastructure.Persistence.Configurations;

public class AttendanceRecordConfiguration : IEntityTypeConfiguration<AttendanceRecord>
{
    public void Configure(EntityTypeBuilder<AttendanceRecord> builder)
    {
        builder.ToTable("attendance_records");

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

        builder.Property(x => x.WorkDate)
               .IsRequired();

        builder.Property(x => x.CheckIn);

        builder.Property(x => x.CheckOut);

        builder.Property(x => x.WorkTypeId)
               .IsRequired();

        builder.HasIndex(x => x.PublicId).IsUnique();

        builder.HasOne(x => x.Employee)
              .WithMany(e => e.AttendanceRecords)
              .HasForeignKey(x => x.EmployeeId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.WorkType)
               .WithMany(e => e.AttendanceRecords)
               .HasForeignKey(x => x.WorkTypeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
