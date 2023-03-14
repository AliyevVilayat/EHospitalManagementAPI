using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class ServiceMapper : Profile
{
    public ServiceMapper()
    {
        CreateMap<Service, ServiceGetDTO>().ReverseMap();
        CreateMap<Service, ServicePostDTO>().ReverseMap();
        CreateMap<Service, ServicePutDTO>().ReverseMap();
    }
}
