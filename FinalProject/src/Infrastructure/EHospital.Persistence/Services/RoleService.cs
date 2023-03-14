using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class RoleService : IRoleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService( IMapper mapper,  RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RoleGetDTO>> GetAllRoleAsync()
    {
        List<IdentityRole> roles = await _unitOfWork.RoleRepository.GetAllRole().ToListAsync();
        List<RoleGetDTO> roleGetDTOs = _mapper.Map<List<RoleGetDTO>>(roles);
        return roleGetDTOs;
    }

    public async Task<RoleGetDTO> GetRoleByIdAsync(string id)
    {
        IdentityRole role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(id);
        if (role is null) throw new NotFoundException("Role not found");

        RoleGetDTO roleGetDTO = _mapper.Map<RoleGetDTO>(role);
        return roleGetDTO;

    }

    public async Task<RoleGetDTO> GetRoleByNameAsync(string name)
    {
        IdentityRole role = await _unitOfWork.RoleRepository.GetSingleRoleByConditionAsync(r => r.Name == name, false);
        if (role is null) throw new NotFoundException("Role not found");

        RoleGetDTO roleGetDTO = _mapper.Map<RoleGetDTO>(role);
        return roleGetDTO;
    }

    public async Task CreateRoleAsync(RolePostDTO rolePostDTO)
    {
        if (await _roleManager.RoleExistsAsync(rolePostDTO.Name)) throw new AddRoleFailException($"Role with this name ({rolePostDTO.Name.ToUpper()}) is already available");

        await _roleManager.CreateAsync(new IdentityRole(rolePostDTO.Name));

    }
    public async Task UpdateRoleAsync(RolePutDTO rolePutDTO)
    {

        IdentityRole role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(rolePutDTO.IdStr);
        if (role is null) throw new NotFoundException("Role not found");
        
        if (await _roleManager.RoleExistsAsync(rolePutDTO.Name) && role.Name.ToUpper() != rolePutDTO.Name.ToUpper()) throw new AddRoleFailException($"Role with this name ({rolePutDTO.Name}) is already available");

        role.Name = rolePutDTO.Name;
        await _roleManager.UpdateAsync(role);
    }

    public async Task DeleteRoleAsync(string id)
    {
        IdentityRole role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(id);
        if (role is null) throw new NotFoundException("Role Not found");

        await _roleManager.DeleteAsync(role);
    }
}
