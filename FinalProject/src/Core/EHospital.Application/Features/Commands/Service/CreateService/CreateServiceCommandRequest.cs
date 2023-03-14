using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Service.CreateInsurance;

public class CreateServiceCommandRequest : IRequest<CreateServiceCommandResponse>
{
    public ServicePostDTO ServicePostDTO { get; set; }
}
