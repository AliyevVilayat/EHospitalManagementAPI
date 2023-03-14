using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class BloodGroupMapper:Profile
{
    public BloodGroupMapper()
    {
        CreateMap<BloodGroup, BloodGroupGetDTO>().ReverseMap();
        CreateMap<BloodGroup, BloodGroupDTO>().ReverseMap();
    }
}
