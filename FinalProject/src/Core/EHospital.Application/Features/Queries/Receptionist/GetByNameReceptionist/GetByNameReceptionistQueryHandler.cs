using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetByNameReceptionist;

public class GetByNameReceptionistQueryHandler : IRequestHandler<GetByNameReceptionistQueryRequest, GetByNameReceptionistQueryResponse>
{
    private readonly IReceptionistService _receptionistService;

    public GetByNameReceptionistQueryHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }
    public async Task<GetByNameReceptionistQueryResponse> Handle(GetByNameReceptionistQueryRequest request, CancellationToken cancellationToken)
    {
        List<ReceptionistGetDTO> receptionistGetDTOs = await _receptionistService.GetReceptionistByNameAsync(request.Page, request.Size, request.Name);
        GetByNameReceptionistQueryResponse response = new() { ReceptionistGetDTOs = receptionistGetDTOs, ReceptionistsCount = receptionistGetDTOs.Count  };
        return response;
    }
}
