namespace TechNotes.Application.Users.AddRoleToUser;

public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
{
    private readonly IUserService _userService;
    public AddRoleToUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<Result> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.AddUserRoleAsync(request.UserId, request.Role);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error al adicionar un rol al usuario: {ex.Message}");
        }

    }
}
