using EmployeeService.Application.Interfaces;
using EmployeeService.Infrastructure.Data;
using EmployeeService.Infrastructure.Persistence;
using EmployeeService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Kernel.Security;

namespace EmployeeService.Infrastructure;
//implement các interface mà Application khai báo, chủ yếu làm vc với database
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("EmployeeDb"),
                x => x.MigrationsAssembly(typeof(EmployeeDbContext).Assembly.FullName));
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddJWTAuthenticationScheme(configuration);
        return services;
    }
}
