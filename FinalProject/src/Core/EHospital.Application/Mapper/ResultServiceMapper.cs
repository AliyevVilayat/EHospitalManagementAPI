using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class ResultServiceMapper:Profile
{
    public ResultServiceMapper()
    {
        CreateMap<ResultService, ResultServiceGetDTO>().ReverseMap();
        CreateMap<ResultService, ResultServicePostDTO>().ReverseMap();
        CreateMap<ResultService, ResultServicePutDTO>().ReverseMap();
    }
}
