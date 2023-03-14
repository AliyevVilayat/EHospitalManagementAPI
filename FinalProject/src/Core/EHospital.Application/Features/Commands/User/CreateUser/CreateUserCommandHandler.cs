using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.UserPostDTO);
        CreateUserCommandResponse response = new() { Message= "User successfully created" };
        return response;
    }
}
