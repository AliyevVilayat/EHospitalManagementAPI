using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetByNameField;

public class GetByNameFieldQueryHandler : IRequestHandler<GetByNameFieldQueryRequest, GetByNameFieldQueryResponse>
{
    private readonly IFieldService _fieldService;

    public GetByNameFieldQueryHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }

    public async Task<GetByNameFieldQueryResponse> Handle(GetByNameFieldQueryRequest request, CancellationToken cancellationToken)
    {
        List<FieldGetDTO> fieldGetDTOs = await _fieldService.GetFieldByNameAsync(request.Page,request.Size,request.Name);
        GetByNameFieldQueryResponse response = new() { FieldGetDTOs = fieldGetDTOs, FieldsCount = fieldGetDTOs.Count };
        return response;
    }
}
