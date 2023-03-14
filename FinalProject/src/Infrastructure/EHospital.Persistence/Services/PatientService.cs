using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PatientGetDTO>> GetAllPatientsAsync()
    {
        List<Patient> patients = await _unitOfWork.PatientReadRepository.GetAll(false, "Gender", "BloodGroup", "Insurance").ToListAsync();
        List<PatientGetDTO> patientGetDTOs = _mapper.Map<List<PatientGetDTO>>(patients);
        for(int i = 0; i < patientGetDTOs.Count; i++)
        {
            patientGetDTOs[i].BloodGroupDTO = _mapper.Map<BloodGroupDTO>(patients[i].BloodGroup);
            patientGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(patients[i].Gender);
            patientGetDTOs[i].InsurancePatientGetDTO = _mapper.Map<InsurancePatientGetDTO>(patients[i].Insurance);

        }
        return patientGetDTOs;
    }

    public async Task<List<PatientGetDTO>> GetAllActivePatientsAsync()
    {
        List<Patient> patients = await _unitOfWork.PatientReadRepository.GetByCondition(p=>p.IsDeleted ==false,false, "Gender", "BloodGroup", "Insurance").ToListAsync();
        List<PatientGetDTO> patientGetDTOs = _mapper.Map<List<PatientGetDTO>>(patients);
        for (int i = 0; i < patientGetDTOs.Count; i++)
        {
            patientGetDTOs[i].BloodGroupDTO = _mapper.Map<BloodGroupDTO>(patients[i].BloodGroup);
            patientGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(patients[i].Gender);
            patientGetDTOs[i].InsurancePatientGetDTO = _mapper.Map<InsurancePatientGetDTO>(patients[i].Insurance);

        }
        return patientGetDTOs;
    }

    public async Task<List<PatientGetDTO>> GetPatientByNameAsync(int page,int size,string name)
    {
        List<Patient> patients = await _unitOfWork.PatientReadRepository.GetByCondition(p => p.Name.Contains(name.Trim()), page,size ,false, "Gender", "BloodGroup", "Insurance").ToListAsync();

        List<PatientGetDTO> patientGetDTOs= _mapper.Map<List<PatientGetDTO>>(patients);
        for (int i = 0; i < patientGetDTOs.Count; i++)
        {
            patientGetDTOs[i].BloodGroupDTO = _mapper.Map<BloodGroupDTO>(patients[i].BloodGroup);
            patientGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(patients[i].Gender);
            patientGetDTOs[i].InsurancePatientGetDTO = _mapper.Map<InsurancePatientGetDTO>(patients[i].Insurance);

        }
        return patientGetDTOs;
    }

    public async Task<PatientGetDTO> GetPatientBySeriaNumberAsync(string seriaNumber)
    {
        Patient patient = await _unitOfWork.PatientReadRepository.GetSingleByConditionAsync(p => p.SeriaNumber == seriaNumber.ToUpper(),false,"Gender", "BloodGroup", "Insurance");
        if (patient is null) throw new Exception("Patient Not found");

        PatientGetDTO patientGetDTO = _mapper.Map<PatientGetDTO>(patient);
        patientGetDTO.BloodGroupDTO = _mapper.Map<BloodGroupDTO>(patient.BloodGroup);
        patientGetDTO.GenderDTO = _mapper.Map<GenderDTO>(patient.Gender);
        patientGetDTO.InsurancePatientGetDTO = _mapper.Map<InsurancePatientGetDTO>(patient.Insurance);
        return patientGetDTO;
    }

    public async Task<PatientGetDTO> GetPatientByIdAsync(string id)
    {
        Patient patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(Guid.Parse(id), "Gender", "BloodGroup", "Insurance");
        if (patient is null) throw new NotFoundException("Not found");

        PatientGetDTO patientGetDTO = _mapper.Map<PatientGetDTO>(patient);
        patientGetDTO.BloodGroupDTO = _mapper.Map<BloodGroupDTO>(patient.BloodGroup);
        patientGetDTO.GenderDTO = _mapper.Map<GenderDTO>(patient.Gender);
        patientGetDTO.InsurancePatientGetDTO = _mapper.Map<InsurancePatientGetDTO>(patient.Insurance);
        return patientGetDTO;
    }
    public async Task CreatePatientAsync(PatientPostDTO patientPostDTO)
    {
        Patient basePatient = await _unitOfWork.PatientReadRepository.GetSingleByConditionAsync(p => p.SeriaNumber == patientPostDTO.SeriaNumber.ToUpper(), false);
        if (basePatient is not null) throw new AlreadyRegisteredException($"Patient(Id:{basePatient.Id}) already registered with this Seria Number");

        Patient patient = _mapper.Map<Patient>(patientPostDTO);
        patient.SeriaNumber = patientPostDTO.SeriaNumber.ToUpper();
        patient.GenderId = Guid.Parse(patientPostDTO.GenderIdStr);
        patient.BloodGroupId = Guid.Parse(patientPostDTO.BloodGroupIdStr);
        patient.InsuranceId = Guid.Parse(patientPostDTO.InsuranceIdStr);

        await _unitOfWork.PatientWriteRepository.CreateAsync(patient);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdatePatientAsync(PatientPutDTO patientPutDTO)
    {
        Patient basePatient = await _unitOfWork.PatientReadRepository.GetSingleByConditionAsync(p => p.Id == Guid.Parse( patientPutDTO.IdStr) && !p.IsDeleted, false);
        if (basePatient is null) throw new NotFoundException("Patient Not found");
        if (patientPutDTO.SeriaNumber.ToUpper() != basePatient.SeriaNumber)
        {
            basePatient = await _unitOfWork.PatientReadRepository.GetSingleByConditionAsync(p => p.SeriaNumber == patientPutDTO.SeriaNumber.ToUpper(), false);
            if (basePatient is not null) throw new AlreadyRegisteredException($"Patient(Id:{basePatient.Id}) already registered with this Seria Number");
        }

        basePatient = await _unitOfWork.PatientReadRepository.GetSingleByConditionAsync(p => p.Id == Guid.Parse(patientPutDTO.IdStr), false);

        Patient patient = _mapper.Map<Patient>(patientPutDTO);
        patient.Id = Guid.Parse(patientPutDTO.IdStr);
        patient.SeriaNumber = patientPutDTO.SeriaNumber.ToUpper();
        patient.GenderId = Guid.Parse(patientPutDTO.GenderIdStr);
        patient.BloodGroupId = Guid.Parse(patientPutDTO.BloodGroupIdStr);
        patient.InsuranceId = Guid.Parse(patientPutDTO.InsuranceIdStr);
        patient.IsDeleted = basePatient.IsDeleted;
        patient.CreatedDate = basePatient.CreatedDate;

        _unitOfWork.PatientWriteRepository.Update(patient);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeletePatientAsync(string id)
    {
        Patient patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(Guid.Parse(id));
        if (patient is null) throw new NotFoundException("Not found");
        if (patient.IsDeleted) throw new AlreadyDeActiveException("Patient already Deactive");

        patient.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeletePatientAsync(string id)
    {
        Patient patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(Guid.Parse(id));
        if (patient is null) throw new NotFoundException("Not found");

        _unitOfWork.PatientWriteRepository.Delete(patient);
        await _unitOfWork.SaveAsync();
    }
}
