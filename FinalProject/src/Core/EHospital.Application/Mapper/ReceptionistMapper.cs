using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class ReceptionistMapper:Profile
{
    public ReceptionistMapper()
    {
        CreateMap<Receptionist, ReceptionistGetDTO>().ReverseMap();
        CreateMap<Receptionist, ReceptionistPostDTO>().ReverseMap();
        CreateMap<Receptionist, ReceptionistPutDTO>().ReverseMap();
    }
}
