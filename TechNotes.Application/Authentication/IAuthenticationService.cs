namespace TechNotes.Application.Authentication;

public interface IAuthenticationService
{
    Task<RegisterUserResponse> RegisterUserAsync(string userName, string email, string password);
    Task<bool> LoginUserAsync(string email, string password);
}
