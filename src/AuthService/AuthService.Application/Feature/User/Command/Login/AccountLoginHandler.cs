
using AuthService.Application.Interface;
using AuthService.Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Shared.Kernel.Exceptions;

namespace AuthService.Application.Feature.User.Command.Login
{
    public sealed class AccountLoginHandler : IRequestHandler<AccountLoginCommand, AccountLoginResponse>
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenFactory _tokenFactory;
        private readonly IPasswordHasher<Account> _passwordHasher;
        public AccountLoginHandler(IAuthRepository authRepository, ITokenFactory tokenFactory, IPasswordHasher<Account> passwordHasher)
        {
            _authRepository = authRepository;
            _tokenFactory = tokenFactory;
            _passwordHasher = passwordHasher;
        }

        public async ValueTask<AccountLoginResponse> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {


            var account = await _authRepository.GetByEmailAsync(request.Email!);
            if (account == null)
            {
                throw new DomainException("Invalid email");
            }
            else
            {
                //var hasher = new PasswordHasher<Account>();

                //var passwordHash = hasher.HashPassword(null, "123456");

                //Console.WriteLine(passwordHash);
                var verifyResult = _passwordHasher.VerifyHashedPassword(
                account,
                account.Password!,
                request.Password!
                 );
                if (verifyResult == PasswordVerificationResult.Failed)
                {
                    throw new DomainException("Invalid password");
                }
                else
                {
                    var claims = new List<KeyValuePair<string, object>>
                    {
                        new ("userId", account.Id),
                        new("email", account.Email)
                    };

                    var accessToken = _tokenFactory.CreateAccessToken(claims, _tokenFactory.AccesstokenExpiredTime);

                    return new AccountLoginResponse
                    {
                        AccessToken = accessToken,
                        ExpiredAt = _tokenFactory.AccesstokenExpiredTime
                    };
                }
            }
        }
    }
}
