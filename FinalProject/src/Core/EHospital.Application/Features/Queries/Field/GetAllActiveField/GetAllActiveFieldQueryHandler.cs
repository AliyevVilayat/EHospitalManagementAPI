using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.Field.GetAllField;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetAllActiveField;

internal class GetAllActiveFieldQueryHandler : IRequestHandler<GetAllActiveFieldQueryRequest, GetAllActiveFieldQueryResponse>
{
    private readonly IFieldService _fieldService;

    public GetAllActiveFieldQueryHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }
    public async Task<GetAllActiveFieldQueryResponse> Handle(GetAllActiveFieldQueryRequest request, CancellationToken cancellationToken)
    {
        List<FieldGetDTO> fieldGetDTOs = await _fieldService.GetAllActiveFieldAsync();
        GetAllActiveFieldQueryResponse response = new() { FieldGetDTOs = fieldGetDTOs,FieldsCount=fieldGetDTOs.Count };
        return response;
    }
}
