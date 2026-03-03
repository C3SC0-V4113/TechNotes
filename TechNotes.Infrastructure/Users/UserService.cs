using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TechNotes.Application.Users;
using TechNotes.Domain.Notes;

namespace TechNotes.Infrastructure.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly INoteRepository _noteRepository;
    public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, INoteRepository noteRepository)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _noteRepository = noteRepository;
    }
    public Task<bool> CurrentUserCanCreateNoteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> CurrentUserCanEditNoteAsync(int noteId)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetCurrentUserIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        throw new NotImplementedException();
    }

    private async Task<User?> GetCurrentUserAsync()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null || httpContext.User == null)
        {
            return null;
        }
        var user = await _userManager.GetUserAsync(httpContext.User);
        return user;
    }
}
