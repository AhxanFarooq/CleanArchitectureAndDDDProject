namespace Dinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthResponse RegisterAsync(string email, string password, string firstName, string lastName);
        AuthResponse LoginAsync(string email, string password);
    }
}