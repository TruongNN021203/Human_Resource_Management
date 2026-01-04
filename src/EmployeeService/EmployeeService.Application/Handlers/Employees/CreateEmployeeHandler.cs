
using EmployeeService.Application.Commands;
using EmployeeService.Application.Interfaces;
using EmployeeService.Domain.Entities;
using Mediator;



namespace EmployeeService.Application.Handlers;

public sealed class CreateEmployeeHandler
    : IRequestHandler<CreateEmployeeCommand, long>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeHandler(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
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
                command.DateOfBirth
            );

            await _employeeRepository.AddAsync(employee, ct);

            await _unitOfWork.CommitAsync();

            return employee.Id;
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}

// public sealed class CreateEmployeeHandler
//     : IRequestHandler<CreateEmployeeCommand, long>
// {
//     private readonly IEmployeeRepository _employeeRepository;

//     public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
//     {
//         _employeeRepository = employeeRepository;
//     }

//     public async ValueTask<long> Handle(

//         CreateEmployeeCommand command,
//         CancellationToken ct)
//     {
//         var exists = await _employeeRepository
//             .EmailExistsAsync(command.Email, ct);

//         if (exists)
//             throw new InvalidOperationException("Employee email already exists");

//         var employee = new Employee(
//             command.Code,
//             command.FullName,
//             command.Email,
//             command.DateOfBirth
//         );

//         await _employeeRepository.AddAsync(employee, ct);

//         return employee.Id;
//     }
// }

