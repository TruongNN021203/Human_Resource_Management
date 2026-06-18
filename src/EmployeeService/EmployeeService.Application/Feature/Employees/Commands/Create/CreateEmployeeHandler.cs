using Contracts.Employees.Events;
using EmployeeService.Application.Interfaces;
using EmployeeService.Domain.Entities;

using Mediator;
namespace EmployeeService.Application.Employees.Commands.Create;

public sealed class CreateEmployeeHandler
    : IRequestHandler<CreateEmployeeCommand, long>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventPublisher _eventPublisher;
    public CreateEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork,
        IEventPublisher eventPublisher)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
        _eventPublisher = eventPublisher;
    }

    public async ValueTask<long> Handle(
        CreateEmployeeCommand command,
        CancellationToken ct)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var exists = await _employeeRepository
                .EmailExistsAsync(command.Email, ct);

            if (exists)
                throw new InvalidOperationException("Employee email already exists");

            var employee = new Employee(
                command.Code,
                command.FullName,
                command.Email,
                command.SalaryGradeId,
                command.DateOfBirth
            );

            await _employeeRepository.AddAsync(employee, ct);

            await _unitOfWork.CommitAsync();
            await _eventPublisher.PublishAsync(
                        new EmployeeCreatedEvent(
                            employee.EmployeeCode,
                            employee.FullName,
                            command.Email,
                            command.DateOfBirth,
                            command.SalaryGradeId,
                            employee.CreatedAt
                            ),
                        ct
                    );
            return employee.Id;
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
