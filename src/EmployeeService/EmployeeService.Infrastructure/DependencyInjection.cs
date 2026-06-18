using EmployeeService.Application.Interfaces;
using EmployeeService.Infrastructure.Data;
using EmployeeService.Infrastructure.Persistence;
using EmployeeService.Infrastructure.Persistence.EventPublisher;
using EmployeeService.Infrastructure.Persistence.Repositories;
using MassTransit;
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
        services.AddScoped<IEventPublisher, EventPublisher>();
        services.AddJWTAuthenticationScheme(configuration);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitHost = configuration["RABBITMQ_HOST"] ?? "rabbitmq";
                var rabbitPort = int.TryParse(configuration["RABBITMQ_PORT"], out var p) ? p : 5672;
                var rabbitUser = configuration["RABBITMQ_DEFAULT_USER"] ?? "guest";
                var rabbitPass = configuration["RABBITMQ_DEFAULT_PASS"] ?? "guest";

                var rabbitUri = new Uri($"localhost://{rabbitHost}:{rabbitPort}/");

                cfg.Host(rabbitUri, h =>
                {
                    h.Username(rabbitUser);
                    h.Password(rabbitPass);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
