using MediatR;
using TechNotes.Domain.User;

namespace TechNotes.Application.Users.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<UserResponse>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public GetUsersQueryHandler(IUserRepository userRepository, IUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }

    public async Task<Result<List<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        bool isAdmin = await _userService.IsCurrentUserInRoleAsync("Admin");
        if (!isAdmin)
        {
            return Result.Fail<List<UserResponse>>("Unauthorized to see all users");
        }
        var users = await _userRepository.GetAllUsersAsync();
        var response = new List<UserResponse>();
        foreach (var user in users)
        {
            var roles = await _userService.GetUserRolesAsync(user.Id);
            var userResponse = user.Adapt<UserResponse>();
            userResponse.Roles = string.Join(", ", roles);
            response.Add(userResponse);
        }
        return response;
    }

}
