using EHospital.Application.DTOs;
using EHospital.Application.Features.Queries.User.GetAllUser;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Queries.User.GetByIdUser;

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
{
    private readonly IUserService _userService;

    public GetByIdUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        UserGetDTO userGetDTO = await _userService.GetUserByIdAsync(request.IdStr);
        GetByIdUserQueryResponse response = new() { UserGetDTO = userGetDTO };
        return response;
    }
}
