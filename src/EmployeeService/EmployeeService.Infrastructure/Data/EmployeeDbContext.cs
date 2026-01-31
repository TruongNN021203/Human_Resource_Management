using EmployeeService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Infrastructure.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }
    // Aggregate roots
    public DbSet<Employee> Employees => Set<Employee>();

    // 1–1 dependent
    public DbSet<EmployeeDetail> EmployeeDetails => Set<EmployeeDetail>();

    // Reference / master data
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<EducationLevel> EducationLevels => Set<EducationLevel>();
    public DbSet<SalaryGrade> SalaryGrades => Set<SalaryGrade>();
    public DbSet<WorkType> WorkTypes => Set<WorkType>();

    // Employee child entities (1–N)
    public DbSet<LaborContract> LaborContracts => Set<LaborContract>();
    public DbSet<Insurance> Insurances => Set<Insurance>();
    public DbSet<Allowance> Allowances => Set<Allowance>();
    public DbSet<RewardDisciplinary> RewardsDisciplinary => Set<RewardDisciplinary>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
