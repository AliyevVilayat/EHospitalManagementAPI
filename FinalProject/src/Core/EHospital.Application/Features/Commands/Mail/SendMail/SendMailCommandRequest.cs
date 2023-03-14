using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Mail.SendMail;

public class SendMailCommandRequest:IRequest<SendMailCommandResponse>
{
    public MailSenderDTO MailSenderDTO { get; set; }
}
