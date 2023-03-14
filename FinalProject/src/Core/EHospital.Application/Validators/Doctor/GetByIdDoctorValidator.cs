using EHospital.Application.Features.Queries.Doctor.GetByIdDoctor;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdDoctorValidator : AbstractValidator<GetByIdDoctorQueryRequest>
{
    public GetByIdDoctorValidator()
    {
        RuleFor(d => d.Id)
            .NotNull()
            .NotEmpty().WithMessage("ID deyeri bos ve ya null deyer ala bilmez");
    }
}
