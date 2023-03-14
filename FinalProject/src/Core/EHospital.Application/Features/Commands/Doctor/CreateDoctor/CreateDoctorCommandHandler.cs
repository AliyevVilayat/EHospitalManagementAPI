using EHospital.Application.Features.Commands.Insurance.UpdateInsurance;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.CreateDoctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommandRequest, CreateDoctorCommandResponse>
{
    private readonly IDoctorService _doctorService;

    public CreateDoctorCommandHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<CreateDoctorCommandResponse> Handle(CreateDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        await _doctorService.CreateDoctorAsync(request.DoctorPostDTO);
        CreateDoctorCommandResponse response = new() { Message = "Doctor successfully created" };
        return response;
    }
}
