using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Account.ResetPassword
{
    public class ResetPasswordCommandRequest:IRequest<ResetPasswordCommandResponse>
    {
        public ResetPasswordDTO ResetPasswordDTO { get; set; }
    }
}