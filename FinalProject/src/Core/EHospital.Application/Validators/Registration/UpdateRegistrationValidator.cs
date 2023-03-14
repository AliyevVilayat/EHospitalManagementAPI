using EHospital.Application.Features.Commands.Registration.UpdateRegistration;
using FluentValidation;

namespace EHospital.Application.Validators;

public class UpdateRegistrationValidator:AbstractValidator<UpdateRegistrationCommandRequest>
{
    public UpdateRegistrationValidator()
    {
        RuleFor(r => r.RegistrationPutDTO.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPutDTO.PatientComplaint)
            .NotNull()
            .NotEmpty().WithMessage("PatientComplaint deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(150).WithMessage("PatientComplaint deyeri 150 simvoldan artiq ola bilmez");

        RuleFor(r => r.RegistrationPutDTO.PatientIdStr)
            .NotNull()
            .NotEmpty().WithMessage("PatientIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPutDTO.DoctorIdStr)
            .NotNull()
            .NotEmpty().WithMessage("DoctorIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPutDTO.ServiceIdStr)
                    .NotNull()
                    .NotEmpty().WithMessage("ServiceIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPutDTO.RoomIdStr)
            .NotNull()
            .NotEmpty().WithMessage("RoomIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPutDTO.AmountPaid)
            .GreaterThan(-1).WithMessage("AmountPaid menfi ola bilmez");
    }
}
