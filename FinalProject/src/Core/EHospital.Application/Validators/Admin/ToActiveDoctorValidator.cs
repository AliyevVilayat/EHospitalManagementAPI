using EHospital.Application.Features.Commands.Admin.ToActiveDoctor;
using FluentValidation;

namespace EHospital.Application.Validators;

public class ToActiveDoctorValidator:AbstractValidator<ToActiveDoctorCommandRequest>
{
    public ToActiveDoctorValidator()
    {
        RuleFor(t => t.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
