using EHospital.Application;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using EHospital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Persistence.Services;

public class AdminService : IAdminService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;

    public AdminService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task ToActiveDoctorAsync(string id)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(Guid.Parse(id));
        if (doctor is null) throw new NotFoundException("Doctor Not found");
        if (!doctor.IsDeleted) throw new AlreadyActiveException("Doctor already Active");

        AppUser user = await _userManager.FindByNameAsync(doctor.SeriaNumber);
        if (user.IsDeleted)
        {
            user.IsDeleted = false;
        }

        doctor.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveFieldAsync(string id)
    {
        Field field = await _unitOfWork.FieldReadRepository.GetByIdAsync(Guid.Parse(id));
        if (field is null) throw new NotFoundException("Field Not found");
        if (!field.IsDeleted) throw new AlreadyActiveException("Field already Active");

        field.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveInsuranceAsync(string id)
    {
        Insurance insurance = await _unitOfWork.InsuranceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (insurance is null) throw new NotFoundException("Insurance Not found");
        if (!insurance.IsDeleted) throw new AlreadyActiveException("Insurance already Active");

        insurance.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActivePatientAsync(string id)
    {
        Patient patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(Guid.Parse(id));
        if (patient is null) throw new NotFoundException("Patient Not found");
        if (!patient.IsDeleted) throw new AlreadyActiveException("Patient already Active");

        patient.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveReceptionistAsync(string id)
    {
        Receptionist receptionist = await _unitOfWork.ReceptionistReadRepository.GetByIdAsync(Guid.Parse(id));
        if (receptionist is null) throw new NotFoundException("Receptionist Not found");
        if (!receptionist.IsDeleted) throw new AlreadyActiveException("Receptionist already Active");

        AppUser user = await _userManager.FindByNameAsync(receptionist.SeriaNumber);
        if (user.IsDeleted)
        {
            user.IsDeleted = false;
        }

        receptionist.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveRoomAsync(string id)
    {
        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(Guid.Parse(id));
        if (room is null) throw new NotFoundException("Room Not found");
        if (!room.IsDeleted) throw new AlreadyActiveException("Room already Active");

        room.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveServiceAsync(string id)
    {
        Service service = await _unitOfWork.ServiceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (service is null) throw new NotFoundException("Service Not found");
        if (!service.IsDeleted) throw new AlreadyActiveException("Service already Active");

        service.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }

    public async Task ToActiveUserAsync(string id)
    {
        AppUser user = await _userManager.FindByIdAsync(id);
        if (user is null) throw new NotFoundException("User Not found");
        if (!user.IsDeleted) throw new AlreadyActiveException("User already Active");

        user.IsDeleted = false;
        await _unitOfWork.SaveAsync();
    }
}
