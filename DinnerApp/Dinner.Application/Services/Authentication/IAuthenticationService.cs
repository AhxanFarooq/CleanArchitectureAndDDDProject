using ErrorOr;

namespace Dinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthResponse> RegisterAsync(string email, string password, string firstName, string lastName);
        ErrorOr<AuthResponse> LoginAsync(string email, string password);
    }
}