using EHospital.Application.Features.Commands.Patient.CreatePatient;
using EHospital.Application.Features.Queries.Patient.GetByIdPatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreatePatientValidator : AbstractValidator<CreatePatientCommandRequest>
{
    public CreatePatientValidator()
    {
        RuleFor(p => p.PatientPostDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.Surname)
            .NotNull()
            .NotEmpty().WithMessage("Surname deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Surname deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage("PhoneNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("PhoneNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(13).WithMessage("PhoneNumber deyeri 13 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.RegistrationAddress)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("RegistrationAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.CurrentAddress)
            .NotNull()
            .NotEmpty().WithMessage("CurrentAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("CurrentAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPostDTO.GenderIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(p => p.PatientPostDTO.BloodGroupIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(p => p.PatientPostDTO.InsuranceIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");
        
    }
}
