using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class InsuranceService : IInsuranceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public InsuranceService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<InsuranceGetDTO>> GetAllInsuranceAsync()
    {
        List<Insurance> insurances = await _unitOfWork.InsuranceReadRepository.GetAll(false, "Patients").ToListAsync();
        List<InsuranceGetDTO> insuranceGetDTOs = _mapper.Map<List<InsuranceGetDTO>>(insurances);
        for (int i = 0; i < insurances.Count; i++)
        {
            insuranceGetDTOs[i].PatientGetDTOs = _mapper.Map<ICollection<PatientGetDTO>>(insurances[i].Patients);
        }

        return insuranceGetDTOs;
    }

    public async Task<InsuranceGetDTO> GetInsuranceByIdAsync(string id)
    {
        Insurance insurance = await _unitOfWork.InsuranceReadRepository.GetByIdAsync(Guid.Parse(id),"Patients");
        if (insurance is null) throw new NotFoundException("Insurance Not found");

        InsuranceGetDTO insuranceGetDTO = _mapper.Map<InsuranceGetDTO>(insurance);
        insuranceGetDTO.PatientGetDTOs = _mapper.Map<ICollection<PatientGetDTO>>(insurance.Patients);
        return insuranceGetDTO;
    }

    public async Task<List<InsuranceGetDTO>> GetInsuranceByNameAsync(int page,int size,string name)
    {
        List<Insurance> insurances = await _unitOfWork.InsuranceReadRepository.GetByCondition(i=>i.PersonInsurance == name,page,size,false, "Patients").ToListAsync();
        List<InsuranceGetDTO> insuranceGetDTOs = _mapper.Map<List<InsuranceGetDTO>>(insurances);

        for (int i = 0; i < insurances.Count; i++)
        {
            insuranceGetDTOs[i].PatientGetDTOs = _mapper.Map<ICollection<PatientGetDTO>>(insurances[i].Patients);
        }

        return insuranceGetDTOs;
    }

    public async Task CreateInsuranceAsync(InsurancePostDTO insurancePostDTO)
    {
        Insurance insurance = _mapper.Map<Insurance>(insurancePostDTO);
        await _unitOfWork.InsuranceWriteRepository.CreateAsync(insurance);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateInsuranceAsync(InsurancePutDTO insurancePutDTO)
    {
        Insurance baseInsurance = await _unitOfWork.InsuranceReadRepository.GetSingleByConditionAsync(i => i.Id == Guid.Parse(insurancePutDTO.IdStr) && !i.IsDeleted, false);
        if (baseInsurance is null) throw new NotFoundException("Not found");

        Insurance insurance = _mapper.Map<Insurance>(insurancePutDTO);
        insurance.Id = Guid.Parse(insurancePutDTO.IdStr);
        insurance.IsDeleted = baseInsurance.IsDeleted;
        insurance.CreatedDate = baseInsurance.CreatedDate;

        _unitOfWork.InsuranceWriteRepository.Update(insurance);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteInsuranceAsync(string id)
    {
        Insurance insurance = await _unitOfWork.InsuranceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (insurance is null) throw new NotFoundException("Not found");
        if (insurance.IsDeleted) throw new AlreadyDeActiveException("Insurance already Deactive");

        insurance.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteInsuranceAsync(string id)
    {
        Insurance insurance = await _unitOfWork.InsuranceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (insurance is null) throw new NotFoundException("Not found");

        _unitOfWork.InsuranceWriteRepository.Delete(insurance);
        await _unitOfWork.SaveAsync();
    }
}
