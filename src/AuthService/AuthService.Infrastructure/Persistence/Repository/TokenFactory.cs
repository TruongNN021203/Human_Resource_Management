using AuthService.Application.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Kernel.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Infrastructure.Persistence.Repository
{
    public class TokenFactory : ITokenFactory
    {
        private readonly JwtSettings _jwtSettings;

        public TokenFactory(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public DateTime AccesstokenExpiredTime =>
          DateTime.UtcNow.AddHours(_jwtSettings.ExpireTimeAccessToken);
        public DateOnly RefreshtokenExpiredTime =>
            DateOnly.FromDateTime(
                DateTime.UtcNow.AddDays(_jwtSettings.ExpireTimeRefreshToken));

        public string CreateAccessToken(
            IEnumerable<KeyValuePair<string, object>> claimList,
            DateTime expirationTime)
        {
            var claims = claimList.Select(c =>
                new Claim(c.Key, c.Value.ToString()!)).ToList();

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public (string TokenValue, string TokenHash, int ExpiredAtUnixSeconds) CreateRefreshToken()
        {
            var bytes = new byte[64];
            RandomNumberGenerator.Fill(bytes);
            var tokenValue = Convert.ToBase64String(bytes);
            var hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(tokenValue));
            var tokenHash = Convert.ToBase64String(hashBytes);

            var expiresAt = DateTime.UtcNow.AddDays(_jwtSettings.ExpireTimeRefreshToken);
            var expiredAtUnix = (int)new DateTimeOffset(expiresAt).ToUnixTimeSeconds();

            return (tokenValue, tokenHash, expiredAtUnix);
        }
    }
}
