using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.User.CreateUser;

public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
{
    public UserPostDTO UserPostDTO { get; set; }
}
