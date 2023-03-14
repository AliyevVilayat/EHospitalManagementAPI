using EHospital.Application.Features.Commands.Doctor.DeleteDoctor;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.UpdateDoctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommandRequest, UpdateDoctorCommandResponse>
{
    private readonly IDoctorService _doctorService;

    public UpdateDoctorCommandHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<UpdateDoctorCommandResponse> Handle(UpdateDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        await _doctorService.UpdateDoctorAsync(request.DoctorPutDTO);
        UpdateDoctorCommandResponse response = new() { Message = "Doctor successfully updated" };
        return response;
    }
}
