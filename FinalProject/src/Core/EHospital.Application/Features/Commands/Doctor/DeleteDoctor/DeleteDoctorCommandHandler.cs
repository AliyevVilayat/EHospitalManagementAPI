using EHospital.Application.Features.Commands.Doctor.CreateDoctor;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Doctor.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommandRequest, DeleteDoctorCommandResponse>
{
    private readonly IDoctorService _doctorService;

    public DeleteDoctorCommandHandler(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<DeleteDoctorCommandResponse> Handle(DeleteDoctorCommandRequest request, CancellationToken cancellationToken)
    {
        await _doctorService.DeleteDoctorAsync(request.Id);
        DeleteDoctorCommandResponse response = new() { Message = "Doctor successfully deleted" };
        return response;
    }
}
