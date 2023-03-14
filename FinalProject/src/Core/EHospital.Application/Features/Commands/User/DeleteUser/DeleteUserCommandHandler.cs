using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(request.IdStr);
        DeleteUserCommandResponse response = new() { Message = "User successfully deleted" };
        return response;
    }
}
