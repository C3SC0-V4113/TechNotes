using TechNotes.Application.Users;

namespace TechNotes.Infrastructure.Users;

public class UserService : IUserService
{
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
}
