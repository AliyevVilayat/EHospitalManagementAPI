
using EHospital.Application.Features.Queries.Room.GetByCodeRoom;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByCodeRoomValidator:AbstractValidator<GetByCodeRoomQueryRequest>
{
    public GetByCodeRoomValidator()
    {
        RuleFor(r => r.Code)
            .NotNull()
            .NotEmpty().WithMessage("Code deyeri bos ve ya null deyer ala bilmez")
            .MaximumLength(16).WithMessage("Name deyeri 16 simvoldan artiq ola bilmez");
    }
}
