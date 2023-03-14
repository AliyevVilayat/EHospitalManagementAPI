using EHospital.Application.Features.Queries.Doctor.GetByNameDoctor;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByNameDoctorValidator:AbstractValidator<GetByNameDoctorQueryRequest>
{
    public GetByNameDoctorValidator()
    {
        RuleFor(d => d.Name)
            .NotNull()
            .NotEmpty().WithMessage("Name deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(50).WithMessage("Name deyeri 50 simvoldan artiq ola bilmez");
    }
}
