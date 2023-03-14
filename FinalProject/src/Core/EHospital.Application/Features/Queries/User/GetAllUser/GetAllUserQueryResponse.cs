using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.User.GetAllUser;

public class GetAllUserQueryResponse
{
    public List<UserGetDTO> UserGetDTOs { get; set; }
    public long UsersCount { get; set; }
}