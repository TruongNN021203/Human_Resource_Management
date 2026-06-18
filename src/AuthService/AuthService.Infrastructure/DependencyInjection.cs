using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Data;
using AuthService.Infrastructure.Messaging.Consumers;
using AuthService.Infrastructure.Persistence.Repository;
using AuthService.Infrastructure.Persistence.UnitOfWork;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Kernel.Security;

namespace AuthService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("AuthDb"),
                x => x.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName));
        });

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddScoped<ITokenFactory, TokenFactory>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<EmployeeCreatedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                var rabbitHost = configuration["RABBITMQ_HOST"] ?? "rabbitmq";
                var rabbitPort = int.TryParse(configuration["RABBITMQ_PORT"], out var p) ? p : 5672;
                var rabbitUser = configuration["RABBITMQ_DEFAULT_USER"] ?? "guest";
                var rabbitPass = configuration["RABBITMQ_DEFAULT_PASS"] ?? "guest";

                var rabbitUri = new Uri($"localhost://{rabbitHost}:{rabbitPort}/");

                cfg.Host(rabbitHost, "/", h =>
                {
                    h.Username(rabbitUser);
                    h.Password(rabbitPass);
                });

                cfg.ReceiveEndpoint("employee-created-queue", e =>
                {
                    e.ConfigureConsumer<EmployeeCreatedConsumer>(context);
                });
            });
        });
        return services;
    }
}