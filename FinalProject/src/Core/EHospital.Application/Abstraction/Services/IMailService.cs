using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IMailService
{
    Task SendMailAsync(MailSenderDTO mailSenderDTO);
    Task SendResetPasswordMail(string username, string id, string to, string token);
    Task SendResultMail(string to, string patientFullName, string doctorName, string serviceName, string result, DateTime registrationDate);
}
