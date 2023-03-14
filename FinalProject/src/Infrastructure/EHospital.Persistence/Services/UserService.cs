using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities.Identity;
using EHospital.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly EHospitalDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(IMapper mapper, EHospitalDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserGetDTO>> GetAllActiveUserAsync()
    {
        List<AppUser> users = await _unitOfWork.UserRepository.GetUserByCondition(u => u.IsDeleted == false, false).ToListAsync();
        List<UserGetDTO> userGetDTOs = _mapper.Map<List<UserGetDTO>>(users);

        IdentityUserRole<string> userRole;
        IdentityRole role;
        string roleId;
        for (int i = 0; i < users.Count; i++)
        {
            userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == users[i].Id);
            roleId = userRole.RoleId;
            role = await _context.Roles.FindAsync(roleId);
            userGetDTOs[i].RoleName = role.Name;
            userGetDTOs[i].RoleId = role.Id;
        }
        return userGetDTOs;
    }

    public async Task<List<UserGetDTO>> GetAllUserAsync()
    {
        List<AppUser> users = await _unitOfWork.UserRepository.GetAllUser().ToListAsync();
        List<UserGetDTO> userGetDTOs = _mapper.Map<List<UserGetDTO>>(users);

        IdentityUserRole<string> userRole;
        IdentityRole role;
        string roleId;
        for (int i = 0; i < users.Count; i++)
        {
            userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == users[i].Id);
            roleId = userRole.RoleId;
            role = await _context.Roles.FindAsync(roleId);
            userGetDTOs[i].RoleName = role.Name;
            userGetDTOs[i].RoleId = role.Id;
        }
        return userGetDTOs;
    }

    public async Task<UserGetDTO> GetUserByIdAsync(string id)
    {
        AppUser user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        if (user is null) throw new NotFoundException("User not found");

        UserGetDTO userGetDTO = _mapper.Map<UserGetDTO>(user);
        var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id);
        string roleId = userRole.RoleId;
        IdentityRole role = await _context.Roles.FindAsync(roleId);
        userGetDTO.RoleName = role.Name;
        userGetDTO.RoleId = role.Id;

        return userGetDTO;
    }

    public async Task<UserGetDTO> GetUserByUserNameAsync(string username)
    {
        AppUser user = await _unitOfWork.UserRepository.GetSingleUserByConditionAsync(u => u.UserName == username);
        if (user is null) throw new NotFoundException("User not found");

        UserGetDTO userGetDTO = _mapper.Map<UserGetDTO>(user);
        var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == user.Id);
        string roleId = userRole.RoleId;
        IdentityRole role = await _context.Roles.FindAsync(roleId);
        userGetDTO.RoleName = role.Name;
        userGetDTO.RoleId = role.Id;

        return userGetDTO;
    }

    public async Task CreateUserAsync(UserPostDTO userPostDTO)
    {

        AppUser baseUser = await _userManager.FindByNameAsync(userPostDTO.UserName);
        if (baseUser is not null)
        {
            throw new AlreadyRegisteredException("Already registered with this Username");
        }

        baseUser = await _userManager.FindByEmailAsync(userPostDTO.Email);
        if (baseUser is not null)
        {
            throw new AlreadyRegisteredException("Already registered with this Email");
        }

        IdentityRole? role = await _roleManager.FindByIdAsync(userPostDTO.RoleIdStr);
        if (role is null) throw new NotFoundException("Role Not found");

        AppUser user = _mapper.Map<AppUser>(userPostDTO);
        user.CreatedDate = DateTime.Now;

        IdentityResult identityResult = await _userManager.CreateAsync(user, userPostDTO.Password);
        if (!identityResult.Succeeded)
        {
            string errors = string.Empty;
            int count = 0;
            foreach (var error in identityResult.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }
            throw new UserCreateFailException(errors);
        }

        IdentityResult identityResultRole = await _userManager.AddToRoleAsync(user, role.Name);
        if (!identityResultRole.Succeeded)
        {
            string errors = string.Empty;
            int count = 0;
            foreach (var error in identityResultRole.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }
            throw new AddRoleFailException(errors);
        }

    }

    public async Task DeleteUserAsync(string id)
    {
        AppUser? user = await _userManager.FindByIdAsync(id);
        if (user is null) throw new NotFoundException("User not found");
        if (user.IsDeleted) throw new AlreadyDeActiveException("User already Deactive");

        user.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task HardDeleteUserAsync(string id)
    {
        AppUser? user = await _userManager.FindByIdAsync(id);
        if (user is null) throw new NotFoundException("User not found");
        await _context.SaveChangesAsync();
    }

}
