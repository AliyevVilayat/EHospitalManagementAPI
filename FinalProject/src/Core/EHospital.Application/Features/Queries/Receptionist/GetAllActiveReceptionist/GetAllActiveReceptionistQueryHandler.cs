using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetAllActiveReceptionist;

public class GetAllActiveReceptionistQueryHandler : IRequestHandler<GetAllActiveReceptionistQueryRequest, GetAllActiveReceptionistQueryResponse>
{
    private readonly IReceptionistService _receptionistService;

    public GetAllActiveReceptionistQueryHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }
    public async Task<GetAllActiveReceptionistQueryResponse> Handle(GetAllActiveReceptionistQueryRequest request, CancellationToken cancellationToken)
    {
        List<ReceptionistGetDTO> receptionistGetDTOs = await _receptionistService.GetAllActiveReceptionistsAsync();
        GetAllActiveReceptionistQueryResponse response = new() { ReceptionistGetDTOs = receptionistGetDTOs,ReceptionistsCount=receptionistGetDTOs.Count };
        return response;
    }
}
