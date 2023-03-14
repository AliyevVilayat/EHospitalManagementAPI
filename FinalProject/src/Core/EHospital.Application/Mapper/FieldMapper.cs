using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class FieldMapper:Profile
{
    public FieldMapper()
    {
        CreateMap<Field, FieldGetDTO>().ReverseMap();
        CreateMap<Field, FieldPostDTO>().ReverseMap();
        CreateMap<Field, FieldPutDTO>().ReverseMap();
        CreateMap<Field, FieldDoctorGetDTO>().ReverseMap();
        CreateMap<Field, FieldServiceGetDTO>().ReverseMap();
    }
}
