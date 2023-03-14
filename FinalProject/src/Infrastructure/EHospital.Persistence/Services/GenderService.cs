using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Repositories;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using EHospital.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class GenderService : IGenderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenderService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GenderGetDTO>> GetAllGenderAsync()
    {
        List<Gender> genders = await _unitOfWork.GenderReadRepository.GetAll(false).ToListAsync();
        List<GenderGetDTO> genderGetDTOs = _mapper.Map<List<GenderGetDTO>>(genders);
        return genderGetDTOs;
    }

    public async Task<GenderGetDTO> GetGenderByIdAsync(string id)
    {
        Gender gender = await _unitOfWork.GenderReadRepository.GetByIdAsync(Guid.Parse(id));
        if (gender is null) throw new NotFoundException("Gender Not found");

        GenderGetDTO genderGetDTO = _mapper.Map<GenderGetDTO>(gender);
        return genderGetDTO;
    }
}
