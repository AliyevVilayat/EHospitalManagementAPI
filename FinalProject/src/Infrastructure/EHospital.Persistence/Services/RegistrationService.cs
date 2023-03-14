using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class RegistrationService : IRegistrationService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrationService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RegistrationGetDTO>> GetAllActiveRegistrationAsync()
    {
        List<Registration> registrations = await _unitOfWork.RegistrationReadRepository.GetByCondition(r => r.IsDeleted == false, false, "Patient", "Doctor", "Service", "Room", "Receptionist").ToListAsync();
        List<RegistrationGetDTO> registrationGetDTOs = _mapper.Map<List<RegistrationGetDTO>>(registrations);
        for (int i = 0; i < registrations.Count; i++)
        {
            registrationGetDTOs[i].PatientGetDTO = _mapper.Map<PatientGetDTO>(registrations[i].Patient);
            registrationGetDTOs[i].DoctorGetDTO = _mapper.Map<DoctorGetDTO>(registrations[i].Doctor);
            registrationGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(registrations[i].Service);
            registrationGetDTOs[i].RoomGetDTO = _mapper.Map<RoomGetDTO>(registrations[i].Room);
            registrationGetDTOs[i].ReceptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(registrations[i].Receptionist);
        }
        return registrationGetDTOs;
    }

    public async Task<List<RegistrationGetDTO>> GetAllRegistrationAsync()
    {
        List<Registration> registrations = await _unitOfWork.RegistrationReadRepository.GetAll(false, "Patient", "Doctor", "Service", "Room", "Receptionist").ToListAsync();
        List<RegistrationGetDTO> registrationGetDTOs = _mapper.Map<List<RegistrationGetDTO>>(registrations);
        for (int i = 0; i < registrations.Count; i++)
        {
            registrationGetDTOs[i].PatientGetDTO = _mapper.Map<PatientGetDTO>(registrations[i].Patient);
            registrationGetDTOs[i].DoctorGetDTO = _mapper.Map<DoctorGetDTO>(registrations[i].Doctor);
            registrationGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(registrations[i].Service);
            registrationGetDTOs[i].RoomGetDTO = _mapper.Map<RoomGetDTO>(registrations[i].Room);
            registrationGetDTOs[i].ReceptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(registrations[i].Receptionist);
        }
        return registrationGetDTOs;
    }

    public async Task<RegistrationGetDTO> GetRegistrationByIdAsync(string id)
    {
        Registration registration = await _unitOfWork.RegistrationReadRepository.GetByIdAsync(Guid.Parse(id), "Patient", "Doctor", "Service", "Room", "Receptionist");
        RegistrationGetDTO registrationGetDTO = _mapper.Map<RegistrationGetDTO>(registration);

        registrationGetDTO.PatientGetDTO = _mapper.Map<PatientGetDTO>(registration.Patient);
        registrationGetDTO.DoctorGetDTO = _mapper.Map<DoctorGetDTO>(registration.Doctor);
        registrationGetDTO.ServiceGetDTO = _mapper.Map<ServiceGetDTO>(registration.Service);
        registrationGetDTO.RoomGetDTO = _mapper.Map<RoomGetDTO>(registration.Room);
        registrationGetDTO.ReceptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(registration.Receptionist);

        return registrationGetDTO;
    }

    public async Task<List<RegistrationGetDTO>> GetRegistrationByDoctorIdAsync(string id)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(Guid.Parse(id));
        if (doctor is null) throw new NotFoundException("Doctor Not found");

        List<Registration> registrations = await _unitOfWork.RegistrationReadRepository.GetByCondition(r => r.IsDeleted == false, false, "Patient", "Doctor", "Service", "Room", "Receptionist").ToListAsync();
        List<RegistrationGetDTO> registrationGetDTOs = _mapper.Map<List<RegistrationGetDTO>>(registrations);
        for (int i = 0; i < registrations.Count; i++)
        {
            registrationGetDTOs[i].PatientGetDTO = _mapper.Map<PatientGetDTO>(registrations[i].Patient);
            registrationGetDTOs[i].DoctorGetDTO = _mapper.Map<DoctorGetDTO>(registrations[i].Doctor);
            registrationGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(registrations[i].Service);
            registrationGetDTOs[i].RoomGetDTO = _mapper.Map<RoomGetDTO>(registrations[i].Room);
            registrationGetDTOs[i].ReceptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(registrations[i].Receptionist);
        }

        List<RegistrationGetDTO> registrationGetDTOsForDoctor = new();
        foreach (var registrationDTO in registrationGetDTOs)
        {
            if (registrationDTO.DoctorGetDTO.Id == Guid.Parse(id))
            {
                registrationGetDTOsForDoctor.Add(registrationDTO);
            }
        }

        return registrationGetDTOsForDoctor;
    }

    public async Task CreateRegistrationAsync(RegistrationPostDTO registrationPostDTO)
    {
        Registration registration = _mapper.Map<Registration>(registrationPostDTO);

        registration.PatientId = Guid.Parse(registrationPostDTO.PatientIdStr);
        registration.DoctorId = Guid.Parse(registrationPostDTO.DoctorIdStr);
        registration.ServiceId = Guid.Parse(registrationPostDTO.ServiceIdStr);
        registration.RoomId = Guid.Parse(registrationPostDTO.RoomIdStr);
        registration.ReceptionistId = Guid.Parse(registrationPostDTO.ReceptionistIdStr);

        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(registration.RoomId);
        room.IsEmpty = false;

        await _unitOfWork.RegistrationWriteRepository.CreateAsync(registration);
        await _unitOfWork.SaveAsync();
    }


    public async Task UpdateRegistrationAsync(RegistrationPutDTO registrationPutDTO)
    {
        Registration baseRegistration = await _unitOfWork.RegistrationReadRepository.GetSingleByConditionAsync(r => r.Id == Guid.Parse(registrationPutDTO.IdStr) && !r.IsDeleted, false);
        if (baseRegistration is null) throw new NotFoundException("Registration Not found");

        Registration registration = _mapper.Map<Registration>(registrationPutDTO);
        registration.Id = Guid.Parse(registrationPutDTO.IdStr);
        registration.PatientId = Guid.Parse(registrationPutDTO.PatientIdStr);
        registration.DoctorId = Guid.Parse(registrationPutDTO.DoctorIdStr);
        registration.ServiceId = Guid.Parse(registrationPutDTO.ServiceIdStr);
        registration.RoomId = Guid.Parse(registrationPutDTO.RoomIdStr);
        registration.ReceptionistId = Guid.Parse(registrationPutDTO.ReceptionistIdStr);
        registration.IsDeleted = baseRegistration.IsDeleted;
        registration.CreatedDate = baseRegistration.CreatedDate;

        if(baseRegistration.RoomId!= Guid.Parse(registrationPutDTO.RoomIdStr))
        {
            Room room = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r=>r.Id==Guid.Parse(registrationPutDTO.RoomIdStr));
            if (!room.IsEmpty) throw new Exception($"Room(id={registrationPutDTO.RoomIdStr}) is not empty");
        }

        _unitOfWork.RegistrationWriteRepository.Update(registration);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteRegistrationAsync(string id)
    {
        Registration registration = await _unitOfWork.RegistrationReadRepository.GetByIdAsync(Guid.Parse(id));
        if (registration is null) throw new NotFoundException("Registration Not found");
        if (registration.IsDeleted) throw new AlreadyDeActiveException("Registration already Deactive");

        registration.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteRegistrationAsync(string id)
    {
        Registration registration = await _unitOfWork.RegistrationReadRepository.GetByIdAsync(Guid.Parse(id));
        if (registration is null) throw new NotFoundException("Registration Not found");

        _unitOfWork.RegistrationWriteRepository.Delete(registration);
        await _unitOfWork.SaveAsync();
    }
}
