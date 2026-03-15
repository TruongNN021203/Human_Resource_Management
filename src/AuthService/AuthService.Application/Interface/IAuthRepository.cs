
using AuthService.Application.Feature.User.Command.Login;
using AuthService.Domain.Entities;

namespace AuthService.Application.Interface
{
    public interface IAuthRepository
    {
        Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
        Task<Account> GetByEmailAsync(string email, CancellationToken ct = default);


    }
}