using Ardalis.ApiEndpoints;
using EmployeeService.Application.Employees.Commands.Create;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Presentation.Routes;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Endpoints.Employees;

[ApiController]
[Route(Router.EmployeeRoutes.Employees)]
public sealed class CreateEmployeeEndpoint(ISender sender)
    : EndpointBaseAsync
        .WithRequest<CreateEmployeeCommand>
        .WithActionResult<long>
{
    [HttpPost]
    [SwaggerOperation(
        Tags = [Router.EmployeeRoutes.Tags],
        Summary = "Create employee"
    )]
    public override async Task<ActionResult<long>> HandleAsync(
        CreateEmployeeCommand request,
        CancellationToken cancellationToken = default)
    {
        var employeeId = await sender.Send(request, cancellationToken);
        return Created(string.Empty, employeeId);
    }
}
