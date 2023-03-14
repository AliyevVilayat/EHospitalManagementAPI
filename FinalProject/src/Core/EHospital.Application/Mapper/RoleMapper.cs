using AutoMapper;
using EHospital.Application.DTOs;
using EHospital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EHospital.Application.Mapper;

public class RoleMapper : Profile
{
    public RoleMapper()
    {
        CreateMap<IdentityRole, RoleGetDTO>().ReverseMap();
        CreateMap<IdentityRole, RolePostDTO>().ReverseMap();
        CreateMap<IdentityRole, RolePutDTO>().ReverseMap();
    }
}
