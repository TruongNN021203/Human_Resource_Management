namespace AuthService.Application.Interface
{
    public interface ITokenFactory
    {
        DateTime AccesstokenExpiredTime { get; }
        DateOnly RefreshtokenExpiredTime { get; }

        string CreateAccessToken(
            IEnumerable<KeyValuePair<string, object>> claimList,
            DateTime expirationTime);
        (string TokenValue, string TokenHash, int ExpiredAtUnixSeconds) CreateRefreshToken();
    }
}
