using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.Field.GetByIdField;

public class GetByIdFieldQueryHandler : IRequestHandler<GetByIdFieldQueryRequest, GetByIdFieldQueryResponse>
{
    private readonly IFieldService _fieldService;

    public GetByIdFieldQueryHandler(IFieldService fieldService)
    {
        _fieldService = fieldService;
    }

    public async Task<GetByIdFieldQueryResponse> Handle(GetByIdFieldQueryRequest request, CancellationToken cancellationToken)
    {
        FieldGetDTO fieldGetDTO = await _fieldService.GetFieldByIdAsync(request.Id);
        GetByIdFieldQueryResponse response = new() { FieldGetDTO = fieldGetDTO };
        return response;
    }
}
