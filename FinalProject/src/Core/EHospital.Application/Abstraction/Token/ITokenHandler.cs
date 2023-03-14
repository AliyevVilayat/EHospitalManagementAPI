using EHospital.Application.DTOs;
using EHospital.Domain.Entities.Identity;

namespace EHospital.Application.Abstraction;

public interface ITokenHandler
{
    Task<TokenResponseDTO> GenerateTokenAsync(AppUser user);
}
