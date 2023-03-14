using EHospital.Application.Abstraction;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Helpers;
using EHospital.Application.Services;
using EHospital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace EHospital.Persistence.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly IMailService _mailService;

    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IMailService mailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _mailService = mailService;
    }

    public async Task<TokenResponseDTO> LoginAsync(LoginDTO loginDTO)
    {
        AppUser user = await _userManager.FindByNameAsync(loginDTO.UsernameOrEmail);
        if (user is null)
        {
            user = await _userManager.FindByEmailAsync(loginDTO.UsernameOrEmail);
            if (user is null)
            {
                throw new AuthFailException();
            }
        }

        if(user.IsDeleted) throw new AuthFailException();

        SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, true);
        if (signInResult.IsLockedOut)
        {
            throw new AuthFailException("Ard-arda 4 defe yanlis sifre daxil etdiyiniz ucun user bir muddetlik blok edildi");
        }
        if (!signInResult.Succeeded)
        {
            throw new AuthFailException();
        }
        
        await _signInManager.SignInAsync(user, loginDTO.RememberMe);
        TokenResponseDTO tokenResponseDTO = await _tokenHandler.GenerateTokenAsync(user);

        return tokenResponseDTO;
    }

    public async Task ForgotPassword(string email)
    {
        AppUser user = await _userManager.FindByEmailAsync(email);
        if (user is null || user.IsDeleted)
        {
            throw new NotFoundException("User Not found");
        }

        string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
        string token = WebEncoders.Base64UrlEncode(tokenBytes);

        await _mailService.SendResetPasswordMail(username: user.UserName, id: user.Id, to: user.Email, token: token);

    }

    public async Task<bool> VerifyResetToken(string id, string resetToken)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        if (user is not null && !user.IsDeleted)
        {
            string token = resetToken.UrlDecoding();
            return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);
        }
        return false;
    }

    public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        AppUser user = await _userManager.FindByIdAsync(resetPasswordDTO.Id);
        if (user is null || user.IsDeleted)
        {
            throw new NotFoundException("User Not found");
        }
        string token = resetPasswordDTO.ResetToken.UrlDecoding();
        IdentityResult identityResult = await _userManager.ResetPasswordAsync(user, token, resetPasswordDTO.Password);
        if (identityResult.Succeeded)
        {
            await _userManager.UpdateSecurityStampAsync(user);
        }
        else
        {
            string errors = string.Empty;
            int count = 0;
            foreach (var error in identityResult.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }
            throw new ResetPasswordFailException(errors);
        }
    }
}
