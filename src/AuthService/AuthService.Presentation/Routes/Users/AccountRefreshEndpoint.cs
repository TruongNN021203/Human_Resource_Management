using Ardalis.ApiEndpoints;
using AuthService.Application.Feature.User.Command.RefreshToken;
using AuthService.Presentation.Endpoints.Users;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Endpoints.Users;

[ApiController]
[Route(Router.AccountRoutes.Account)]
public sealed class AccountRefreshEndpoint(ISender sender)
    : EndpointBaseAsync
        .WithRequest<RefreshTokenCommand>
        .WithActionResult<RefreshTokenResponse>
{
    [HttpPost("refresh")]
    [SwaggerOperation(
        Tags = [Router.AccountRoutes.Tags],
        Summary = "Refresh access token",
        Description = "Exchange a valid refresh token for a new access token and a new refresh token. The previous refresh token is invalidated.")]
    public override async Task<ActionResult<RefreshTokenResponse>> HandleAsync(
        [FromBody] RefreshTokenCommand request,
        CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(request, cancellationToken);
        return Ok(result);
    }
}
