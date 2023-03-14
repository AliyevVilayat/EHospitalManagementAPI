using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Insurance.CreateInsurance;

public class CreateInsuranceCommandRequest : IRequest<CreateInsuranceCommandResponse>
{
    public InsurancePostDTO InsurancePostDTO { get; set; }
}
