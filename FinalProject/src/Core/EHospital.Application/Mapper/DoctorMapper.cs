using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class DoctorMapper:Profile
{
    public DoctorMapper()
    {
        CreateMap<Doctor,DoctorGetDTO>().ReverseMap();
        CreateMap<Doctor,DoctorPostDTO>().ReverseMap();
        CreateMap<Doctor,DoctorPutDTO>().ReverseMap();
    }
}
