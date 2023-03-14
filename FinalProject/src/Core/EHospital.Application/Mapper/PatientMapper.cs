using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class PatientMapper:Profile
{
    public PatientMapper()
    {
        CreateMap<Patient, PatientGetDTO>().ReverseMap();
        CreateMap<Patient, PatientPostDTO>().ReverseMap();
        CreateMap<Patient, PatientPutDTO>().ReverseMap();
    }
}
