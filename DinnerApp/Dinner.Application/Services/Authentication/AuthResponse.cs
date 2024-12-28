namespace Dinner.Application.Services.Authentication
{
    public record AuthResponse
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Token { get; set; }
        public Guid Id { get; set; }
    }
}