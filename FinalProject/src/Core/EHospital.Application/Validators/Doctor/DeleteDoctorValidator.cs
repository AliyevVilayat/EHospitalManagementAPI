using EHospital.Application.Features.Commands.Doctor.DeleteDoctor;
using FluentValidation;

namespace EHospital.Application.Validators;

public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorCommandRequest>
{
    public DeleteDoctorValidator()
    {
        RuleFor(d => d.Id)
            .NotNull()
            .NotEmpty().WithMessage("Id deyeri bos ve ya null deyer ala bilmez");
    }
}
