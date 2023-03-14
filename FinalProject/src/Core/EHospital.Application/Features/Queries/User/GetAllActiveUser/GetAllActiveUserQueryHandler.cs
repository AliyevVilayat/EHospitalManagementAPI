using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.User.GetAllActiveUser;

public class GetAllActiveUserQueryHandler : IRequestHandler<GetAllActiveUserQueryRequest, GetAllActiveUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllActiveUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAllActiveUserQueryResponse> Handle(GetAllActiveUserQueryRequest request, CancellationToken cancellationToken)
    {
        List<UserGetDTO> userGetDTOs = await _userService.GetAllActiveUserAsync();
        GetAllActiveUserQueryResponse response = new() { UserGetDTOs = userGetDTOs, UsersCount = userGetDTOs.Count };
        return response;
    }
}
