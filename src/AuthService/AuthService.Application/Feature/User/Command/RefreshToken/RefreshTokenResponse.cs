namespace AuthService.Application.Feature.User.Command.RefreshToken;

public class RefreshTokenResponse
{
    public string AccessToken { get; set; } = null!;
    public DateTime AccessTokenExpiredAt { get; set; }
    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpiresAt { get; set; }
}
