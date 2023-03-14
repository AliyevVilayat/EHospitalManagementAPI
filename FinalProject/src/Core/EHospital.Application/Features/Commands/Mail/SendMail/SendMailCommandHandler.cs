using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Mail.SendMail;

public class SendMailCommandHandler : IRequestHandler<SendMailCommandRequest, SendMailCommandResponse>
{
    private readonly IMailService _mailService;

    public SendMailCommandHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task<SendMailCommandResponse> Handle(SendMailCommandRequest request, CancellationToken cancellationToken)
    {
        await _mailService.SendMailAsync(request.MailSenderDTO);
        SendMailCommandResponse response = new() { Message= "Email sent successfully" };
        return response;
    }
}
