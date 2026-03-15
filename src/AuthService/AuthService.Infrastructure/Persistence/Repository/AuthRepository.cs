using AuthService.Application.Feature.User.Command.Login;
using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Data;
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
            return await _dbContext.Accounts.AnyAsync(x => x.Email == email);
        }

        public async Task<Account?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            return await _dbContext.Accounts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, ct);
        }

    }
}
