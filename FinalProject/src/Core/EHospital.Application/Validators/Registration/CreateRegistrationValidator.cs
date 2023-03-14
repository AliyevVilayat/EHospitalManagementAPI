using EHospital.Application.Features.Commands.Registration.CreateRegistration;
using FluentValidation;

namespace EHospital.Application.Validators;

public class CreateRegistrationValidator:AbstractValidator<CreateRegistrationCommandRequest>
{
    public CreateRegistrationValidator()
    {
        RuleFor(r => r.RegistrationPostDTO.PatientComplaint)
            .NotNull()
            .NotEmpty().WithMessage("PatientComplaint deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(150).WithMessage("PatientComplaint deyeri 150 simvoldan artiq ola bilmez");

        RuleFor(r => r.RegistrationPostDTO.PatientIdStr)
            .NotNull()
            .NotEmpty().WithMessage("PatientIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPostDTO.DoctorIdStr)
            .NotNull()
            .NotEmpty().WithMessage("DoctorIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPostDTO.ServiceIdStr)
                    .NotNull()
                    .NotEmpty().WithMessage("ServiceIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPostDTO.RoomIdStr)
            .NotNull()
            .NotEmpty().WithMessage("RoomIdStr deyeri bos ve ya null deyer ala bilmez");

        RuleFor(r => r.RegistrationPostDTO.AmountPaid)            
            .GreaterThan(-1).WithMessage("AmountPaid menfi ola bilmez");
    }
}
