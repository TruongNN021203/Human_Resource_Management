using EmployeeService.Application.Interfaces;
using MassTransit;

namespace EmployeeService.Infrastructure.Persistence.EventPublisher
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventPublisher(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync<T>(T message, CancellationToken ct)
        {
            await _publishEndpoint.Publish(message, ct);
        }
    }
}