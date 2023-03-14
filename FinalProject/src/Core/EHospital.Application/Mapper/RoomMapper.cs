using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mapper;

public class RoomMapper:Profile
{
    public RoomMapper()
    {
        CreateMap<Room, RoomDTO>().ReverseMap();
        CreateMap<Room, RoomGetDTO>().ReverseMap();
        CreateMap<Room, RoomPostDTO>().ReverseMap();
        CreateMap<Room, RoomPutDTO>().ReverseMap();
    }
}
