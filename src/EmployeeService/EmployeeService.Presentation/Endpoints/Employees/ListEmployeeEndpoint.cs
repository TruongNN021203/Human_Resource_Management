using Ardalis.ApiEndpoints;
using EmployeeService.Application.Employees.Queries.List;
using EmployeeService.Application.Queries.List;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Routes;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Endpoints.Employees;

[ApiController]
[Route(Router.EmployeeRoutes.Employees)]
[Authorize]
public sealed class ListEmployeeEndpoint(ISender sender)
    : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<IReadOnlyList<GetListEmployeeResponse>>
{
    [HttpGet]
    [SwaggerOperation(
        Tags = [Router.EmployeeRoutes.Tags],
        Summary = "Get list of employees"
    )]
    public override async Task<ActionResult<IReadOnlyList<GetListEmployeeResponse>>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new GetListEmployeeQuery(), cancellationToken);
        return Ok(result);
    }
}
