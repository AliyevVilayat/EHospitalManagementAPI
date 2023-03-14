using MediatR;

namespace EHospital.Application.Features.Commands.Service.DeleteInsurance;

public class DeleteServiceCommandRequest:IRequest<DeleteServiceCommandResponse>
{
    public string? Id { get; set; }
}
