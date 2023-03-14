using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Receptionist.GetByIdReceptionist;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Receptionist.GetBySeriaNumberReceptionist;

public class GetBySeriaNumberReceptionistQueryHandler : IRequestHandler<GetBySeriaNumberReceptionistQueryRequest, GetBySeriaNumberReceptionistQueryResponse>
{
    private readonly IReceptionistService _receptionistService;

    public GetBySeriaNumberReceptionistQueryHandler(IReceptionistService receptionistService)
    {
        _receptionistService = receptionistService;
    }
    public async Task<GetBySeriaNumberReceptionistQueryResponse> Handle(GetBySeriaNumberReceptionistQueryRequest request, CancellationToken cancellationToken)
    {
        ReceptionistGetDTO receptionistGetDTO = await _receptionistService.GetReceptionistBySeriaNumberAsync(request.SeriaNumber);
        GetBySeriaNumberReceptionistQueryResponse response = new() { ReceptionistGetDTO = receptionistGetDTO };
        return response;
    }
}
