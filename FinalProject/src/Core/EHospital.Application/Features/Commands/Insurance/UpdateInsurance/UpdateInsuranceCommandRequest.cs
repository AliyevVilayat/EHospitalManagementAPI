using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.UpdateInsurance;

public class UpdateInsuranceCommandRequest:IRequest<UpdateInsuranceCommandResponse>
{
    public InsurancePutDTO InsurancePutDTO { get; set; }
}
