using Contracts.Common;

namespace Contracts.Employees.Events;

public record EmployeeCreatedEvent : IntegrationEvent
{
    public string PublicId { get; init; } = default!;
    public string EmployeeCode { get; init; } = default!;
    public string FullName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public DateTimeOffset JoinDate { get; init; }
}
