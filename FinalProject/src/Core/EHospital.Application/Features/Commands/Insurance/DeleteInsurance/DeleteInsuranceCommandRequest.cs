using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.DeleteInsurance;

public class DeleteInsuranceCommandRequest:IRequest<DeleteInsuranceCommandResponse>
{
    public string? Id { get; set; }
}
