using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class ResultServiceService : IResultServiceService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMailService _mailService;

    public ResultServiceService(IMapper mapper, IMailService mailService, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _mailService = mailService;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ResultServiceGetDTO>> GetAllActiveResultServiceAsync()
    {
        List<ResultService> resultServices = await _unitOfWork.ResultServiceReadRepository.GetByCondition(r => r.IsDeleted == false, false, "Registration").ToListAsync();
        List<ResultServiceGetDTO> resultServiceGetDTOs = _mapper.Map<List<ResultServiceGetDTO>>(resultServices);
        for (int i = 0; i < resultServices.Count; i++)
        {
            resultServiceGetDTOs[i].RegistrationDTO = _mapper.Map<RegistrationDTO>(resultServices[i].Registration);
        }
        return resultServiceGetDTOs;
    }

    public async Task<List<ResultServiceGetDTO>> GetAllResultServiceAsync()
    {
        List<ResultService> resultServices = await _unitOfWork.ResultServiceReadRepository.GetAll(false, "Registration").ToListAsync();
        List<ResultServiceGetDTO> resultServiceGetDTOs = _mapper.Map<List<ResultServiceGetDTO>>(resultServices);
        for (int i = 0; i < resultServices.Count; i++)
        {
            resultServiceGetDTOs[i].RegistrationDTO = _mapper.Map<RegistrationDTO>(resultServices[i].Registration);
        }
        return resultServiceGetDTOs;
    }

    public async Task<ResultServiceGetDTO> GetResultServiceByIdAsync(string id)
    {
        ResultService resultService = await _unitOfWork.ResultServiceReadRepository.GetByIdAsync(Guid.Parse(id), "Registration");
        if (resultService is null) throw new NotFoundException("ResultService Not found");

        ResultServiceGetDTO resultServiceGetDTO = _mapper.Map<ResultServiceGetDTO>(resultService);
        resultServiceGetDTO.RegistrationDTO = _mapper.Map<RegistrationDTO>(resultService.Registration);
        return resultServiceGetDTO;
    }

    public async Task CreateResultServiceAsync(ResultServicePostDTO resultServicePostDTO)
    {
        ResultService resultService = _mapper.Map<ResultService>(resultServicePostDTO);
        resultService.RegistrationId = Guid.Parse(resultServicePostDTO.RegistrationIdStr);

        Registration registration = await _unitOfWork.RegistrationReadRepository.GetByIdAsync(resultService.RegistrationId, "Patient", "Service", "Room", "Doctor");
        if (registration is null || registration.IsDeleted) throw new NotFoundException("Registration Not found");

        if (registration.ItPaid)
        {
            registration.IsDeleted = true;
        }

        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(registration.RoomId);
        room.IsEmpty = true;

        await _unitOfWork.ResultServiceWriteRepository.CreateAsync(resultService);
        await _unitOfWork.SaveAsync();

        if (registration.Patient.Email is not null)
        {
            await _mailService.SendResultMail(registration.Patient.Email, registration.Patient.Name + " " + registration.Patient.Surname, registration.Doctor.Name + " " + registration.Doctor.Surname, resultServicePostDTO.Result, registration.Service.Name, registration.CreatedDate);
        }
    }
    public async Task UpdateResultServiceAsync(ResultServicePutDTO resultServicePutDTO)
    {
        ResultService baseResultService = await _unitOfWork.ResultServiceReadRepository.GetSingleByConditionAsync(r => r.Id == Guid.Parse(resultServicePutDTO.IdStr) && !r.IsDeleted, false);
        if (baseResultService is null) throw new NotFoundException("ResultService Not found");

        ResultService resultService = _mapper.Map<ResultService>(resultServicePutDTO);
        resultService.Id = Guid.Parse(resultServicePutDTO.IdStr);
        resultService.RegistrationId = Guid.Parse(resultServicePutDTO.RegistrationIdStr);
        resultService.IsDeleted = baseResultService.IsDeleted;
        resultService.CreatedDate = baseResultService.CreatedDate;

        _unitOfWork.ResultServiceWriteRepository.Update(resultService);
        await _unitOfWork.SaveAsync();
    }
    public async Task DeleteResultServiceAsync(string id)
    {
        ResultService resultService = await _unitOfWork.ResultServiceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (resultService is null) throw new NotFoundException("ResultService Not found");
        if (resultService.IsDeleted) throw new AlreadyDeActiveException("ResultService already Deactive");

        resultService.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteResultServiceAsync(string id)
    {
        ResultService resultService = await _unitOfWork.ResultServiceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (resultService is null) throw new NotFoundException("ResultService Not found");
        _unitOfWork.ResultServiceWriteRepository.Delete(resultService);
        await _unitOfWork.SaveAsync();
    }
}
