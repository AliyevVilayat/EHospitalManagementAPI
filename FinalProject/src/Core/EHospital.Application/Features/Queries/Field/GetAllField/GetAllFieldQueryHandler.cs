using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetAllField;

public class GetAllFieldQueryHandler : IRequestHandler<GetAllFieldQueryRequest, GetAllFieldQueryResponse>
{
    private readonly IFieldService _fieldService;

    public GetAllFieldQueryHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }

    public async Task<GetAllFieldQueryResponse> Handle(GetAllFieldQueryRequest request, CancellationToken cancellationToken)
    {
        List<FieldGetDTO> fieldGetDTOs = await _fieldService.GetAllFieldAsync();
        GetAllFieldQueryResponse response = new() { FieldGetDTOs = fieldGetDTOs, FieldsCount = fieldGetDTOs.Count };
        return response;
    }
}
