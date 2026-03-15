using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Shared.Kernel.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Application.Feature.User.Command.RefreshToken;

public sealed class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
{
    private readonly IAuthRepository _authRepository;
    private readonly ITokenFactory _tokenFactory;

    public RefreshTokenHandler(IAuthRepository authRepository, ITokenFactory tokenFactory)
    {
        _authRepository = authRepository;
        _tokenFactory = tokenFactory;
    }

    public async ValueTask<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.RefreshToken))
            throw new DomainException("Refresh token is required.");

        var tokenHash = HashRefreshToken(request.RefreshToken);
        var account = await _authRepository.GetAccountByRefreshTokenAsync(tokenHash, cancellationToken);
        if (account == null)
            throw new DomainException("Invalid or expired refresh token.");

        await _authRepository.RevokeRefreshTokenAsync(tokenHash, cancellationToken);

        var claims = new List<KeyValuePair<string, object>>
        {
            new("userId", account.Id),
            new("email", account.Email)
        };
        var accessToken = _tokenFactory.CreateAccessToken(claims, _tokenFactory.AccesstokenExpiredTime);
        var (refreshValue, refreshHash, refreshExpiredUnix) = _tokenFactory.CreateRefreshToken();
        var familyId = Guid.NewGuid().ToString("N");
        await _authRepository.AddRefreshTokenAsync(
            account.Id,
            refreshHash,
            null,
            familyId,
            refreshExpiredUnix,
            cancellationToken);

        var refreshExpiresAt = DateTimeOffset.FromUnixTimeSeconds(refreshExpiredUnix).UtcDateTime;

        return new RefreshTokenResponse
        {
            AccessToken = accessToken,
            AccessTokenExpiredAt = _tokenFactory.AccesstokenExpiredTime,
            RefreshToken = refreshValue,
            RefreshTokenExpiresAt = refreshExpiresAt
        };
    }

    private static string HashRefreshToken(string tokenValue)
    {
        var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(tokenValue));
        return Convert.ToBase64String(hashBytes);
    }
}
