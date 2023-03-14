using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class ServiceService : IServiceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ServiceGetDTO>> GetAllServicesAsync()
    {
        List<Service> services = await _unitOfWork.ServiceReadRepository.GetAll(false, "Field","Rooms").ToListAsync();
        List<ServiceGetDTO> serviceGetDTOs = _mapper.Map<List<ServiceGetDTO>>(services);        
        
        for (int i = 0; i < serviceGetDTOs.Count; i++)
        {
            serviceGetDTOs[i].FieldServiceGetDTO = _mapper.Map<FieldServiceGetDTO>(services[i].Field);
            serviceGetDTOs[i].RoomDTOs = _mapper.Map<List<RoomDTO>>(services[i].Rooms);
        }
        return serviceGetDTOs;
    }
    public async Task<List<ServiceGetDTO>> GetAllActiveServicesAsync()
    {
        List<Service> services = await _unitOfWork.ServiceReadRepository.GetByCondition(s=>s.IsDeleted ==false,false, "Field", "Rooms").ToListAsync();
        List<ServiceGetDTO> serviceGetDTOs = _mapper.Map<List<ServiceGetDTO>>(services);

        for (int i = 0; i < serviceGetDTOs.Count; i++)
        {
            serviceGetDTOs[i].FieldServiceGetDTO = _mapper.Map<FieldServiceGetDTO>(services[i].Field);
            serviceGetDTOs[i].RoomDTOs = _mapper.Map<List<RoomDTO>>(services[i].Rooms);
        }
        return serviceGetDTOs;
    }

    public async Task<List<ServiceGetDTO>> GetServiceByNameAsync(int page, int size, string name)
    {
        List<Service> services = await _unitOfWork.ServiceReadRepository.GetByCondition(s=>s.Name.Contains(name.Trim()),page,size,false, "Field","Rooms").ToListAsync();
        List<ServiceGetDTO> serviceGetDTOs = _mapper.Map<List<ServiceGetDTO>>(services);

        for (int i = 0; i < serviceGetDTOs.Count; i++)
        {
            serviceGetDTOs[i].FieldServiceGetDTO = _mapper.Map<FieldServiceGetDTO>(services[i].Field);
            serviceGetDTOs[i].RoomDTOs = _mapper.Map<List<RoomDTO>>(services[i].Rooms);
        }
        return serviceGetDTOs;
    }

    public async Task<ServiceGetDTO> GetServiceByIdAsync(string id)
    {
        Service service = await _unitOfWork.ServiceReadRepository.GetByIdAsync(Guid.Parse(id), "Field", "Rooms");
        if (service is null) throw new NotFoundException("Service Not found");

        ServiceGetDTO serviceGetDTO = _mapper.Map<ServiceGetDTO>(service);
        serviceGetDTO.FieldServiceGetDTO = _mapper.Map<FieldServiceGetDTO>(service.Field);
        serviceGetDTO.RoomDTOs = _mapper.Map<List<RoomDTO>>(service.Rooms);
        return serviceGetDTO;
    }

    public async Task CreateServiceAsync(ServicePostDTO servicePostDTO)
    {
        Service service = _mapper.Map<Service>(servicePostDTO);
        service.FieldId = Guid.Parse(servicePostDTO.FieldIdStr);

        await _unitOfWork.ServiceWriteRepository.CreateAsync(service);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateServiceAsync(ServicePutDTO servicePutDTO)
    {
        Service baseService = await _unitOfWork.ServiceReadRepository.GetSingleByConditionAsync(s => s.Id == Guid.Parse(servicePutDTO.IdStr) && !s.IsDeleted , false);
        if (baseService is null) throw new NotFoundException("Service Not found");

        Service service = _mapper.Map<Service>(servicePutDTO);
        service.Id = Guid.Parse(servicePutDTO.IdStr);
        service.FieldId = Guid.Parse(servicePutDTO.FieldIdStr);
        service.IsDeleted = baseService.IsDeleted;
        service.CreatedDate = baseService.CreatedDate;

        _unitOfWork.ServiceWriteRepository.Update(service);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteServiceAsync(string id)
    {
        Service service = await _unitOfWork.ServiceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (service is null) throw new NotFoundException("Service Not found");
        if (service.IsDeleted) throw new AlreadyDeActiveException("Service already Deactive");

        service.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteServiceAsync(string id)
    {
        Service service = await _unitOfWork.ServiceReadRepository.GetByIdAsync(Guid.Parse(id));
        if (service is null) throw new NotFoundException("Service Not found");

        _unitOfWork.ServiceWriteRepository.Delete(service);
        await _unitOfWork.ServiceWriteRepository.SaveAsync();
    }

}
