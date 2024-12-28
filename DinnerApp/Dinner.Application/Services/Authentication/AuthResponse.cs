namespace Dinner.Application.Services.Authentication
{
    public record AuthResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public Guid Id { get; set; }
    }
}