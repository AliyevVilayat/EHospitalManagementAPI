using EHospital.Application.DTOs;
using MediatR;

namespace EHospital.Application.Features.Commands.Service.UpdateInsurance;

public class UpdateServiceCommandRequest:IRequest<UpdateServiceCommandResponse>
{
    public ServicePutDTO ServicePutDTO { get; set; }
}
