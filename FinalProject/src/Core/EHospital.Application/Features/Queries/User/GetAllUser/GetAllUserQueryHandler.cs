using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.User.GetAllActiveUser;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.User.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        List<UserGetDTO> userGetDTOs = await _userService.GetAllUserAsync();
        GetAllUserQueryResponse response = new() { UserGetDTOs = userGetDTOs,UsersCount=userGetDTOs.Count };
        return response;
    }
}
