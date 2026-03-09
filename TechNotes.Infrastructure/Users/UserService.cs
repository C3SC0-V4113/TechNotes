using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TechNotes.Application.Exceptions;
using TechNotes.Application.Users;
using TechNotes.Domain.Notes;

namespace TechNotes.Infrastructure.Users;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly INoteRepository _noteRepository;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, INoteRepository noteRepository, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _noteRepository = noteRepository;
        _roleManager = roleManager;
    }

    public async Task AddUserRoleAsync(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new UserNotAuthorizedException();
        }
        if (!await _roleManager.RoleExistsAsync(role))
        {
            var roleResult = _roleManager.CreateAsync(new IdentityRole(role));
            if (!roleResult.Result.Succeeded)
            {
                throw new Exception($"Failed to create role: {role}");
            }
        }
        var result = await _userManager.AddToRoleAsync(user, role);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to add role '{role}' to user '{user.UserName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    public async Task<bool> CurrentUserCanCreateNoteAsync()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return false;
        }

        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        var isWriter = await _userManager.IsInRoleAsync(user, "Writer");
        return isAdmin || isWriter;
    }

    public async Task<bool> CurrentUserCanEditNoteAsync(int noteId)
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            return false;
        }
        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
        var isWriter = await _userManager.IsInRoleAsync(user, "Writer");

        var note = await _noteRepository.GetNoteByIdAsync(noteId);
        if (note == null)
        {
            return false;
        }
        var isAuthorized = isAdmin || (isWriter && note.UserId == user.Id);
        return isAuthorized;
    }

    public async Task<string> GetCurrentUserIdAsync()
    {
        var user = await GetCurrentUserAsync();
        if (user == null)
        {
            throw new UserNotAuthorizedException();
        }
        return user.Id;
    }

    public async Task<string[]> GetUserRolesAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return [];
        }
        var roles = await _userManager.GetRolesAsync(new User { Id = user.Id });
        return roles.ToArray();
    }

    public async Task<bool> IsCurrentUserInRoleAsync(string role)
    {
        var user = await GetCurrentUserAsync();
        var isUserInRole = user != null && await _userManager.IsInRoleAsync(user, role);
        return isUserInRole;
    }

    public async Task RemoveRoleFromUserAsync(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            throw new Exception($"Failed to find role: {roleName}");
        }
        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to remove role '{roleName}' to user '{user.UserName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
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
