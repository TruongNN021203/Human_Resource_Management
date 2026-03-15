using Ardalis.ApiEndpoints;
using AuthService.Application.Feature.User.Command.Login;
using AuthService.Presentation.Endpoints.Users;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Endpoints.Users
{
    [ApiController]
    [Route(Router.AccountRoutes.Account)]
    public sealed class AccountLoginEndpoint(ISender sender)
        : EndpointBaseAsync
        .WithRequest<AccountLoginCommand>
        .WithActionResult<AccountLoginResponse>
    {
        [HttpPost]
        [SwaggerOperation(
            Tags = [Router.AccountRoutes.Tags],
            Summary = "Login to account"
            )]
        public override async Task<ActionResult<AccountLoginResponse>> HandleAsync(
            [FromBody] AccountLoginCommand request,
            CancellationToken cancellationToken = default)
        {
            var result = await sender.Send(request, cancellationToken);
            return Ok(result);
        }
    }
}
