namespace AuthService.Application.Feature.User.Command.Login
{
    public class AccountLoginResponse
    {
        public string AccessToken { get; set; } = null!;
        public DateTime AccessTokenExpiredAt { get; set; }
        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenExpiresAt { get; set; }
    }
}
