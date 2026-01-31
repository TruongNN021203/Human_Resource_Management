using EmployeeService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeService.Infrastructure;

public class EmployeeDbContextFactory
    : IDesignTimeDbContextFactory<EmployeeDbContext>
{
    public EmployeeDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile("appsettings.Development.json", true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString =
            config.GetConnectionString("EmployeeDb");

        Console.WriteLine("EF DESIGN-TIME CONNECTION:");
        Console.WriteLine(connectionString);

        var options = new DbContextOptionsBuilder<EmployeeDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new EmployeeDbContext(options);
    }
}
