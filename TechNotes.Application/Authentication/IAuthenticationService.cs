using TechNotes.Application.Authentication;

namespace TechNotes.Application.Abstractions;

public interface IAuthenticationService
{
    Task<RegisterUserResponse> RegisterUserAsync(string userName, string email, string password);
    Task<bool> LoginUserAsync(string email, string password);
}
