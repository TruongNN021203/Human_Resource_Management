using AuthService.Application.Feature.User.Command.CreateAccount;
using Contracts.Employees.Events;
using MassTransit;
using Mediator;


namespace AuthService.Infrastructure.Messaging.Consumers
{
    public class EmployeeCreatedConsumer : IConsumer<EmployeeCreatedEvent>
    {
        private readonly IMediator _mediator;

        public EmployeeCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<EmployeeCreatedEvent> context)
        {
            var message = context.Message;

            await _mediator.Send(new CreateEmployeeCommand(
                message.EmployeeCode,
                message.FullName,
                message.Email,
                message.DateOfBirth,
                message.SalaryGradeId
                ));
        }
    }
}
