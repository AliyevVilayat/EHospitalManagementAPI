using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.Login;

public class LoginCommandRequest:IRequest<LoginCommandResponse>
{
    public LoginDTO LoginDTO { get; set; }
}
