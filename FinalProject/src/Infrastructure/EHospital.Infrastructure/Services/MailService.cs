using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EHospital.Infrastructure.Services;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;
    private readonly MailSettings _mailSettings;

    public MailService(IConfiguration configuration, IOptions<MailSettings> mailSettings)
    {
        _configuration = configuration;
        _mailSettings = mailSettings.Value;
    }

    public async Task SendMailAsync(MailSenderDTO mailSenderDTO)
    {

        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
        email.To.Add(MailboxAddress.Parse(mailSenderDTO.To));
        email.Subject = mailSenderDTO.Subject;
        var builder = new BodyBuilder();

        builder.HtmlBody = mailSenderDTO.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }

    public async Task SendResetPasswordMail(string username,string id,string to,string token)
    {
        MailSenderDTO mailSenderDTO = new() { To = to, Subject = "Reset Password" };
        mailSenderDTO.Body = $"Hi {username},<br><br>There was a request to change your password!<br>If you did not make this request then please ignore this email.<br>Otherwise, please click this link to change your password: " + "<a href='" + _configuration["Server"] + "api/AccountsControllers/verify-reset-token" + $"?Id={id}" + $"&ResetToken={token}" + "'>Reset Password</a>";

        await this.SendMailAsync(mailSenderDTO);
    }

    public async Task SendResultMail(string to, string patientFullName, string doctorName, string serviceName, string result, DateTime registrationDate)
    {
        MailSenderDTO mailSenderDTO = new() { To = to, Subject = $"{serviceName} Result" };
        mailSenderDTO.Body = $"Hi {patientFullName},<br><br>Here are the results of the service provided to you by Dr.{doctorName} at our hospital on {registrationDate.Day}.{registrationDate.Month}.{registrationDate.Year} <br><br> Result:{result} <br><br> Thank you for entrusting us with your health.<br><br>Sincerely, E-Hospital";

        await this.SendMailAsync(mailSenderDTO);
    }
}
