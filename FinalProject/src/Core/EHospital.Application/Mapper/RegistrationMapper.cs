using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class RegistrationMapper:Profile
{
    public RegistrationMapper()
    {
        CreateMap<Registration, RegistrationDTO>().ReverseMap();
        CreateMap<Registration, RegistrationGetDTO>().ReverseMap();
        CreateMap<Registration, RegistrationPostDTO>().ReverseMap();
        CreateMap<Registration, RegistrationPutDTO>().ReverseMap();
    }
}
