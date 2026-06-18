using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Data;
using Domain.Aggregates.Accounts;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Infrastructure.Persistence.Repository
{
    public sealed class AuthRepository : IAuthRepository
    {
        private readonly AuthDbContext _dbContext;

        public AuthRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken ct)
        {
            return await _dbContext.Accounts.AnyAsync(x => x.Email == email, ct);
        }

        public async Task<Account?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, ct);
        }

        public async Task AddRefreshTokenAsync(long accountId, string tokenHash, string? clientIp, string familyId, int expiredAtUnixSeconds, CancellationToken ct = default)
        {
            var token = new AccountToken
            {
                Token = tokenHash,
                ClientIp = clientIp,
                FamilyId = familyId,
                AccountId = accountId,
                ExpiredTime = expiredAtUnixSeconds
            };
            await _dbContext.AccountTokens.AddAsync(token, ct);
            await _dbContext.SaveChangesAsync(ct);
        }

        public async Task<Account?> GetAccountByRefreshTokenAsync(string tokenHash, CancellationToken ct = default)
        {
            var nowUnix = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var token = await _dbContext.AccountTokens
                .AsNoTracking()
                .Include(t => t.Account)
                .FirstOrDefaultAsync(t => t.Token == tokenHash && t.ExpiredTime > nowUnix, ct);
            return token?.Account;
        }

        public async Task RevokeRefreshTokenAsync(string tokenHash, CancellationToken ct = default)
        {
            var token = await _dbContext.AccountTokens
                .FirstOrDefaultAsync(t => t.Token == tokenHash, ct);
            if (token != null)
            {
                _dbContext.AccountTokens.Remove(token);
                await _dbContext.SaveChangesAsync(ct);
            }
        }
    }
}
