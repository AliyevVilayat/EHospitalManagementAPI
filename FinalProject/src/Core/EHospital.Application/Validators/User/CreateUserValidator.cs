using EHospital.Application.Features.Commands.User.CreateUser;
using FluentValidation;

namespace EHospital.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserValidator()
    {

        RuleFor(u => u.UserPostDTO.Fullname)
            .NotEmpty()
            .NotNull().WithMessage("Fullname deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(5);

        RuleFor(u => u.UserPostDTO.UserName)
            .NotEmpty()
            .NotNull().WithMessage("UserName deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(3);

        RuleFor(u => u.UserPostDTO.Email)
            .NotEmpty()
            .NotNull().WithMessage("Email deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(3)
            .EmailAddress();

        RuleFor(u => u.UserPostDTO.Password)
            .NotEmpty()
            .NotNull().WithMessage("Password deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250);


        RuleFor(u => u.UserPostDTO.ConfirmPassword)
            .Equal(u => u.UserPostDTO.Password)
            .NotEmpty()
            .NotNull().WithMessage("ConfirmPassword deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(8);

        RuleFor(u => u.UserPostDTO.RoleIdStr)
            .NotNull()
            .NotEmpty().WithMessage("RoleIdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
