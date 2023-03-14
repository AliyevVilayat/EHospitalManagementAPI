using EHospital.Application.Features.Commands.Patient.UpdatePatient;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdatePatientValidator:AbstractValidator<UpdatePatientCommandRequest>
{
    public UpdatePatientValidator()
    {
        RuleFor(p => p.PatientPutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(p => p.PatientPutDTO.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.Surname)
            .NotNull()
            .NotEmpty().WithMessage("Surname deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Surname deyeri 50 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage("PhoneNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("PhoneNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(13).WithMessage("PhoneNumber deyeri 13 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.SeriaNumber)
            .NotNull()
            .NotEmpty().WithMessage("SeriaNumber deyeri bos ve ya null deyer ala bilmez")
            .MinimumLength(9).WithMessage("SeriaNumber deyeri 9 simvoldan az ola bilmez")
            .MaximumLength(11).WithMessage("SeriaNumber deyeri 11 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.RegistrationAddress)
            .NotNull()
            .NotEmpty().WithMessage("RegistrationAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("RegistrationAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.CurrentAddress)
            .NotNull()
            .NotEmpty().WithMessage("CurrentAddress deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(100).WithMessage("CurrentAddress deyeri 100 simvoldan artiq ola bilmez");

        RuleFor(p => p.PatientPutDTO.GenderIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(p => p.PatientPutDTO.BloodGroupIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(p => p.PatientPutDTO.InsuranceIdStr)
            .NotNull()
            .NotEmpty().WithMessage("GenderIdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
