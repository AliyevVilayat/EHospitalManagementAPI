using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Mapper;

public class UserMapper:Profile
{
    public UserMapper()
    {
        CreateMap<AppUser, UserGetDTO>().ReverseMap();
        CreateMap<AppUser, UserPostDTO>().ReverseMap();
    }
}
