namespace Dinner.Infrastructure.Authentication
{
    public class JwtSetting
    {
        public const string Jwt  = "Jwt";
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
        public string SecretKey { get; set; }
    }
}