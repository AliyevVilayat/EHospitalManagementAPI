using EHospital.Application.DTOs;
using EHospital.Application.Services;
using MediatR;

namespace EHospital.Application.Features.Commands.Registration.CreateRegistration;

public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommandRequest, CreateRegistrationCommandResponse>
{
    private readonly IRegistrationService _registrationService;
    private readonly IPatientService _patientService;
    private readonly IDoctorService _doctorService;
    private readonly IReceptionistService _receptionistService;
    private readonly IRoomService _roomService;

    public CreateRegistrationCommandHandler(IRegistrationService registrationService, IPatientService patientService, IDoctorService doctorService, IReceptionistService receptionistService, IRoomService roomService)
    {
        _registrationService = registrationService;
        _patientService = patientService;
        _doctorService = doctorService;
        _receptionistService = receptionistService;
        _roomService = roomService;
    }

    public async Task<CreateRegistrationCommandResponse> Handle(CreateRegistrationCommandRequest request, CancellationToken cancellationToken)
    {
        await _registrationService.CreateRegistrationAsync(request.RegistrationPostDTO);

        PatientGetDTO patientGetDTO = await _patientService.GetPatientByIdAsync(request.RegistrationPostDTO.PatientIdStr);
        DoctorGetDTO doctorGetDTO = await _doctorService.GetDoctorByIdAsync(request.RegistrationPostDTO.DoctorIdStr);
        ReceptionistGetDTO receptionistGetDTO = await _receptionistService.GetReceptionistByIdAsync(request.RegistrationPostDTO.ReceptionistIdStr);
        RoomGetDTO roomGetDTO = await _roomService.GetRoomByIdAsync(request.RegistrationPostDTO.RoomIdStr);

        CheckDTO checkDTO = new();
        checkDTO.PatientFullName = patientGetDTO.Name + patientGetDTO.Surname;
        checkDTO.DoctorFullName = doctorGetDTO.Name + doctorGetDTO.Surname;
        checkDTO.ReceptionistFullName = receptionistGetDTO.Name + receptionistGetDTO.Surname;
        checkDTO.RoomCode = roomGetDTO.RoomCode;
        checkDTO.AmountPaid = request.RegistrationPostDTO.AmountPaid;
        checkDTO.PrintDate = DateTime.Now;

        CreateRegistrationCommandResponse response = new() { CheckDTO = checkDTO, Message = "Registration successfully created" };
        return response;
    }
}
