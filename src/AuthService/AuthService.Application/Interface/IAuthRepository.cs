using AuthService.Domain.Entities;

namespace AuthService.Application.Interface
{
    public interface IAuthRepository
    {
        Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
        Task<Account?> GetByEmailAsync(string email, CancellationToken ct = default);

        Task AddRefreshTokenAsync(long accountId, string tokenHash, string? clientIp, string familyId, int expiredAtUnixSeconds, CancellationToken ct = default);
        Task<Account?> GetAccountByRefreshTokenAsync(string tokenHash, CancellationToken ct = default);
        Task RevokeRefreshTokenAsync(string tokenHash, CancellationToken ct = default);
    }
}