using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Data;
using AuthService.Infrastructure.Persistence.Repository;
using AuthService.Infrastructure.Persistence.UnitOfWork;
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
        return services;
    }
}