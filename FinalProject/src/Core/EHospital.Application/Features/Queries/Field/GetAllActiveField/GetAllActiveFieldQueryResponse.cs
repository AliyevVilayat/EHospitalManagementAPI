using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.Field.GetAllActiveField;

public class GetAllActiveFieldQueryResponse
{
    public List<FieldGetDTO> FieldGetDTOs { get; set; }
    public long FieldsCount { get; set; }
}
