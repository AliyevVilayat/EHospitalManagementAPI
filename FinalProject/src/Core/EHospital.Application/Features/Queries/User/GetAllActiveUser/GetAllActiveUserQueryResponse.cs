using EHospital.Application.DTOs;

namespace EHospital.Application.Features.Queries.User.GetAllActiveUser;

public class GetAllActiveUserQueryResponse
{
    public List<UserGetDTO> UserGetDTOs { get; set; }
    public long UsersCount { get; set; }
}