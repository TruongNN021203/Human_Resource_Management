namespace AuthService.Presentation.Endpoints.Users
{
    public static class Router
    {
        public static class AccountRoutes
        {
            public const string Tags = "Accounts";
            public const string Account = "api/account";
            public const string Login = $"{Account}/login";
            public const string Refresh = $"{Account}/refresh";
        }
    }
}
