using Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeService.Application;

//dùng để đăng ký các service nội bộ của Application
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        return services;
    }
}
