using MediatR;

namespace EHospital.Application.Features.Commands.Admin.ToActiveInsurance;

public class ToActiveInsuranceCommandRequest:IRequest<ToActiveInsuranceCommandResponse>
{
    public string? Id { get; set; }
}