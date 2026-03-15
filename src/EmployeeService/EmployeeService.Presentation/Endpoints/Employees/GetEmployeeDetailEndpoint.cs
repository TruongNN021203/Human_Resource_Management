using Application.Feature.Employees.Queries.Detail;
using Ardalis.ApiEndpoints;
using Contracts.ApiWrapper;
using EmployeeService.Application.Employees.Queries.Detail;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Routes;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Endpoints.Employees;

[ApiController]
[Route(Router.EmployeeRoutes.Employees)]
//[Authorize]
public sealed class GetEmployeeDetailEndpoint(ISender sender)
    : EndpointBaseAsync
        .WithRequest<long>
        .WithActionResult<Result<GetEmployeeDetailResponse>>
{
    [HttpGet("{id:long}")]
    [SwaggerOperation(
        Tags = [Router.EmployeeRoutes.Tags],
        Summary = "Get employee detail by id"
    )]
    public override async Task<ActionResult<Result<GetEmployeeDetailResponse>>> HandleAsync(
        [FromRoute] long id,
        CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(
            new GetEmployeeDetailQuery { EmployeeId = id },
            cancellationToken);

        if (!result.Success)
            return NotFound(result);

        return Ok(result);
    }
}
