using EHospital.Application.DTOs;

namespace EHospital.Application.Services;

public interface IFieldService
{
    Task<List<FieldGetDTO>> GetAllFieldAsync();
    Task<List<FieldGetDTO>> GetAllActiveFieldAsync();
    Task<FieldGetDTO> GetFieldByIdAsync(string id);
    Task<List<FieldGetDTO>> GetFieldByNameAsync(int page, int size, string name);

    Task CreateFieldAsync(FieldPostDTO fieldPostDTO);
    Task UpdateFieldAsync(FieldPutDTO fieldPutDTO);
    Task DeleteFieldAsync(string id);
    Task HardDeleteFieldAsync(string id);
}
