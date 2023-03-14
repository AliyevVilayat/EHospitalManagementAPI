using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class GenderMapper:Profile
{
    public GenderMapper()
    {
        CreateMap<Gender, GenderGetDTO>().ReverseMap();
        CreateMap<Gender, GenderDTO>().ReverseMap();
    }
}
