using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Repositories;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class BloodGroupService : IBloodGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BloodGroupService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BloodGroupGetDTO>> GetAllBloodGroupAsync()
    {
        List<BloodGroup> bloodGroups = await _unitOfWork.BloodGroupReadRepository.GetAll(false).ToListAsync();
        List<BloodGroupGetDTO> bloodGroupGetDTOs = _mapper.Map<List<BloodGroupGetDTO>>(bloodGroups);
        return bloodGroupGetDTOs;
    }

    public async Task<BloodGroupGetDTO> GetBloodGroupByIdAsync(string id)
    {
        BloodGroup bloodGroup = await _unitOfWork.BloodGroupReadRepository.GetByIdAsync(Guid.Parse(id));
        if (bloodGroup is null) throw new NotFoundException("BloodGroup Not found");

        BloodGroupGetDTO bloodGroupGetDTO = _mapper.Map<BloodGroupGetDTO>(bloodGroup);
        return bloodGroupGetDTO;
    }
}
