using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.User.GetByIdUser;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.User.GetByUserNameUser;

public class GetByUserNameUserQueryHandler : IRequestHandler<GetByUserNameUserQueryRequest, GetByUserNameUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetByUserNameUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<GetByUserNameUserQueryResponse> Handle(GetByUserNameUserQueryRequest request, CancellationToken cancellationToken)
    {
        UserGetDTO userGetDTO = await _userService.GetUserByUserNameAsync(request.UserName);
        GetByUserNameUserQueryResponse response = new() { UserGetDTO = userGetDTO };
        return response;
    }
}
