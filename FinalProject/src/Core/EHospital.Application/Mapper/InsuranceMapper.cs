using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class InsuranceMapper:Profile
{
    public InsuranceMapper()
    {
        CreateMap<Insurance, InsuranceGetDTO>().ReverseMap();
        CreateMap<Insurance, InsurancePostDTO>().ReverseMap();
        CreateMap<Insurance, InsurancePutDTO>().ReverseMap();
        CreateMap<Insurance, InsurancePatientGetDTO>().ReverseMap();
    }
}
