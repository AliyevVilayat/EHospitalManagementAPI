using EHospital.Application.Features.Queries.Registration.GetByDoctorIdRegistration;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByDoctorIdRegistrationValidator:AbstractValidator<GetByDoctorIdRegistrationRequest>
{
    public GetByDoctorIdRegistrationValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
