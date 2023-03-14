using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Repositories;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class FieldService : IFieldService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FieldService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<FieldGetDTO>> GetAllFieldAsync()
    {
        List<Field> fields = await _unitOfWork.FieldReadRepository.GetAll(false,"Doctors","Services").ToListAsync();
        List<FieldGetDTO> fieldGetDTOs = _mapper.Map<List<FieldGetDTO>>(fields);

        for (int i = 0; i < fields.Count; i++)
        {
            fieldGetDTOs[i].DoctorGetDTOs = _mapper.Map<ICollection<DoctorGetDTO>>(fields[i].Doctors);
            fieldGetDTOs[i].ServiceGetDTOs = _mapper.Map<ICollection<ServiceGetDTO>>(fields[i].Services);
        }
        return fieldGetDTOs;
    }

    public async Task<List<FieldGetDTO>> GetAllActiveFieldAsync()
    {
        List<Field> fields = await _unitOfWork.FieldReadRepository.GetByCondition(f=>f.IsDeleted ==false,false, "Doctors", "Services").ToListAsync();
        List<FieldGetDTO> fieldGetDTOs = _mapper.Map<List<FieldGetDTO>>(fields);

        for (int i = 0; i < fields.Count; i++)
        {
            fieldGetDTOs[i].DoctorGetDTOs = _mapper.Map<ICollection<DoctorGetDTO>>(fields[i].Doctors);
            fieldGetDTOs[i].ServiceGetDTOs = _mapper.Map<ICollection<ServiceGetDTO>>(fields[i].Services);
        }
        return fieldGetDTOs;
    }

    public async Task<List<FieldGetDTO>> GetFieldByNameAsync(int page, int size, string name)
    {
        List<Field> fields = await _unitOfWork.FieldReadRepository.GetByCondition(f => f.PersonField.Contains(name.Trim()), page, size, false, "Doctors", "Services").ToListAsync();
        List<FieldGetDTO> fieldGetDTOs = _mapper.Map<List<FieldGetDTO>>(fields);

        for (int i = 0; i < fields.Count; i++)
        {
            fieldGetDTOs[i].DoctorGetDTOs = _mapper.Map<ICollection<DoctorGetDTO>>(fields[i].Doctors);
            fieldGetDTOs[i].ServiceGetDTOs = _mapper.Map<ICollection<ServiceGetDTO>>(fields[i].Services);
        }
        return fieldGetDTOs;
    }

    public async Task<FieldGetDTO> GetFieldByIdAsync(string id)
    {
        Field field = await _unitOfWork.FieldReadRepository.GetByIdAsync(Guid.Parse(id),"Doctors","Services");
        if (field is null) throw new NotFoundException("Field Not found");

        FieldGetDTO fieldGetDTO = _mapper.Map<FieldGetDTO>(field);
        fieldGetDTO.DoctorGetDTOs = _mapper.Map<ICollection<DoctorGetDTO>>(field.Doctors);
        fieldGetDTO.ServiceGetDTOs = _mapper.Map<ICollection<ServiceGetDTO>>(field.Services);

        return fieldGetDTO;
    }

    public async Task CreateFieldAsync(FieldPostDTO fieldPostDTO)
    {
        Field field = _mapper.Map<Field>(fieldPostDTO);
        await _unitOfWork.FieldWriteRepository.CreateAsync(field);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateFieldAsync(FieldPutDTO fieldPutDTO)
    {
        Field baseField = await _unitOfWork.FieldReadRepository.GetSingleByConditionAsync(f => f.Id == Guid.Parse(fieldPutDTO.IdStr) && !f.IsDeleted, false);
        if (baseField is null) throw new NotFoundException("Not found");

        Field field = _mapper.Map<Field>(fieldPutDTO);
        field.Id = Guid.Parse(fieldPutDTO.IdStr);
        field.IsDeleted = baseField.IsDeleted;
        field.CreatedDate = baseField.CreatedDate;

        _unitOfWork.FieldWriteRepository.Update(field);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteFieldAsync(string id)
    {
        Field field = await _unitOfWork.FieldReadRepository.GetByIdAsync(Guid.Parse(id));
        if (field is null) throw new NotFoundException("Not found");
        if (field.IsDeleted) throw new AlreadyDeActiveException("Field already Deactive");


        field.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteFieldAsync(string id)
    {
        Field field = await _unitOfWork.FieldReadRepository.GetByIdAsync(Guid.Parse(id));
        if (field is null) throw new NotFoundException("Not found");

        _unitOfWork.FieldWriteRepository.Delete(field);
        await _unitOfWork.SaveAsync();
    }
}
