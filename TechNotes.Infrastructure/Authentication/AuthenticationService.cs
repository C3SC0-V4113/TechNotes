using Microsoft.AspNetCore.Identity;
using TechNotes.Application.Authentication;

namespace TechNotes.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    public async Task<bool> LoginUserAsync(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
        return result.Succeeded;
    }

    public async Task<RegisterUserResponse> RegisterUserAsync(string userName, string email, string password)
    {
        var user = new User { UserName = userName, Email = email, EmailConfirmed = true };
        var result = await _userManager.CreateAsync(user, password);
        return new RegisterUserResponse
        {
            Errors = result.Errors.Select(e => e.Description).ToList(),
            Succeeded = result.Succeeded
        };
    }
}
