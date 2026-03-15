using Mediator;

namespace AuthService.Application.Feature.User.Command.RefreshToken;

public record RefreshTokenCommand(string? RefreshToken) : IRequest<RefreshTokenResponse>;
