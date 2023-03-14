using EHospital.Application.Features.Commands.Receptionist.CreateReceptionist;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateReceptionistValidator:AbstractValidator<CreateReceptionistCommandRequest>
{
    public CreateReceptionistValidator()
    {
        RuleFor(r => r.ReceptionistPostDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.Surname)
            .NotNull()
            .NotEmpty().WithMessage("Surname deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Surname deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage("PhoneNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("PhoneNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(13).WithMessage("PhoneNumber deyeri 13 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.RegistrationAddress)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("RegistrationAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.CurrentAddress)
            .NotNull()
            .NotEmpty().WithMessage("CurrentAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("CurrentAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.GenderIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.ReceptionistPostDTO.Salary)
            .NotNull()
            .NotEmpty().WithMessage("Salary deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Discount menfi ola bilmez");

        RuleFor(r => r.ReceptionistPostDTO.VOEN)
            .NotNull()
            .NotEmpty().WithMessage("VOEN deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(10).WithMessage("VOEN deyeri 10 simvoldan az ola bilmez")
            .MaximumLength(10).WithMessage("VOEN deyeri 10 simvoldan artiq ola bilmez");

        RuleFor(u => u.ReceptionistPostDTO.Email)
            .NotEmpty()
            .NotNull().WithMessage("Email deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(3)
            .EmailAddress();
    }
}
