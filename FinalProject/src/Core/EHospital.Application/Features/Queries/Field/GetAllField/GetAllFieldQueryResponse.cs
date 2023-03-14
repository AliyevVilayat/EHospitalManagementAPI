using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Field.GetAllField;

public class GetAllFieldQueryResponse
{
    public List<FieldGetDTO> FieldGetDTOs { get; set; }
    public long FieldsCount { get; set; }
}
