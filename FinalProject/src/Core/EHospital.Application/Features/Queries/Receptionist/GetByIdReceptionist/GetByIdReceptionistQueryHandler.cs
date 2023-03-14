using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Receptionist.GetAllReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetByIdReceptionist;

public class GetByIdReceptionistQueryHandler:IRequestHandler<GetByIdReceptionistQueryRequest,GetByIdReceptionistQueryResponse>
{
    private readonly IReceptionistService _receptionistService;

    public GetByIdReceptionistQueryHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }

    public async Task<GetByIdReceptionistQueryResponse> Handle(GetByIdReceptionistQueryRequest request, CancellationToken cancellationToken)
    {
        ReceptionistGetDTO receptionistGetDTO = await _receptionistService.GetReceptionistByIdAsync(request.IdStr);
        GetByIdReceptionistQueryResponse response = new() { ReceptionistGetDTO = receptionistGetDTO };
        return response;
    }
}
