using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.User.DeleteUser;

public class DeleteUserCommandRequest:IRequest<DeleteUserCommandResponse>
{
    public string? IdStr { get; set; }
}
