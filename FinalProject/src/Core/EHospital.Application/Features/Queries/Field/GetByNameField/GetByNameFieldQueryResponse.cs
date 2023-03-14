using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Field.GetByNameField;

public class GetByNameFieldQueryResponse
{
    public List<FieldGetDTO> FieldGetDTOs { get; set; }
    public long FieldsCount { get; set; }
}
