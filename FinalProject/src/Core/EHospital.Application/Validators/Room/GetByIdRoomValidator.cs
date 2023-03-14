using EHospital.Application.Features.Queries.Room.GetByIdRoom;
using EHospital.Domain.Entities;
using FluentValidation;

namespace EHospital.Application.Validators;

public class GetByIdRoomValidator:AbstractValidator<GetByIdRoomQueryRequest>
{
    public GetByIdRoomValidator()
    {
        RuleFor(r => r.IdStr)
            .NotNull()
            .NotEmpty().WithMessage("IdStr deyeri bos ve ya null deyer ala bilmez");
    }
}
