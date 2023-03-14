using EHospital.Application.Features.Commands.Doctor.CreateDoctor;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateDoctorValidator:AbstractValidator<CreateDoctorCommandRequest>
{
    public CreateDoctorValidator()
    {
        RuleFor(d => d.DoctorPostDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.Surname)
            .NotNull()
            .NotEmpty().WithMessage("Surname deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Surname deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage("PhoneNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("PhoneNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(13).WithMessage("PhoneNumber deyeri 13 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.RegistrationAddress)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("RegistrationAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.CurrentAddress)
            .NotNull()
            .NotEmpty().WithMessage("CurrentAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("CurrentAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.GenderIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(d => d.DoctorPostDTO.ExperienceYear)            
            .NotNull()
            .NotEmpty().WithMessage("ExperienceYear deyeri bos ve ya null deyer ala bilmez")
            .GreaterThanOrEqualTo(1).WithMessage("ExperienceYear 1-den az ola bilmez");

        RuleFor(d => d.DoctorPostDTO.FieldIdStr)
            .NotNull()
            .NotEmpty().WithMessage("FieldIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(d => d.DoctorPostDTO.Salary)
            .NotNull()
            .NotEmpty().WithMessage("Salary deyeri bos ve ya null deyer ala bilmez")
            .GreaterThan(-1).WithMessage("Discount menfi ola bilmez");

        RuleFor(d => d.DoctorPostDTO.VOEN)
            .NotNull()
            .NotEmpty().WithMessage("VOEN deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(10).WithMessage("VOEN deyeri 10 simvoldan az ola bilmez")
            .MaximumLength(10).WithMessage("VOEN deyeri 10 simvoldan artiq ola bilmez");

        RuleFor(d => d.DoctorPostDTO.Email)
            .NotEmpty()
            .NotNull().WithMessage("Email deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(250)
            .MinimumLength(3)
            .EmailAddress();
    }
}
