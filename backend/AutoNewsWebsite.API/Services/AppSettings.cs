namespace AutoNewsWebsite.API.Services
{
    public static class AppSettings
    {
        public static string Token { get; } = "[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]";
    }
}