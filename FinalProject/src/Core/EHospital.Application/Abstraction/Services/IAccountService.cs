using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IAccountService
{
    Task<TokenResponseDTO> LoginAsync(LoginDTO loginDTO);
    Task ForgotPassword(string email);
    Task<bool> VerifyResetToken(string id, string resetToken);
    Task ResetPassword(ResetPasswordDTO resetPasswordDTO);
}
