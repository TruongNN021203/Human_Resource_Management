namespace Shared.Kernel.Security
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpireTimeAccessToken { get; set; }
        public int ExpireTimeRefreshToken { get; set; }
    }
}
