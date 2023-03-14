using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using EHospital.Domain.Entities.Identity;
using EHospital.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class ReceptionistService : IReceptionistService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public ReceptionistService(IMapper mapper, IUserService userService, IRoleService roleService, IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _userService = userService;
        _roleService = roleService;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<List<ReceptionistGetDTO>> GetAllReceptionistsAsync()
    {
        List<Receptionist> receptionists = await _unitOfWork.ReceptionistReadRepository.GetAll(false, "Gender").ToListAsync();
        List<ReceptionistGetDTO> receptionistGetDTOs = _mapper.Map<List<ReceptionistGetDTO>>(receptionists);

        for (int i = 0; i < receptionistGetDTOs.Count; i++)
        {
            receptionistGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(receptionists[i].Gender);
        }
        return receptionistGetDTOs;
    }

    public async Task<List<ReceptionistGetDTO>> GetAllActiveReceptionistsAsync()
    {
        List<Receptionist> receptionists = await _unitOfWork.ReceptionistReadRepository.GetByCondition(r => r.IsDeleted == false, false, "Gender").ToListAsync();
        List<ReceptionistGetDTO> receptionistGetDTOs = _mapper.Map<List<ReceptionistGetDTO>>(receptionists);

        for (int i = 0; i < receptionistGetDTOs.Count; i++)
        {
            receptionistGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(receptionists[i].Gender);
        }
        return receptionistGetDTOs;
    }

    public async Task<ReceptionistGetDTO> GetReceptionistByIdAsync(string id)
    {
        Receptionist receptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(d => d.Id == Guid.Parse(id), true, "Gender");
        if (receptionist is null) throw new NotFoundException("Receptionist Not found");

        ReceptionistGetDTO receptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(receptionist);
        receptionistGetDTO.GenderDTO = _mapper.Map<GenderDTO>(receptionist.Gender);

        return receptionistGetDTO;
    }

    public async Task<List<ReceptionistGetDTO>> GetReceptionistByNameAsync(int page, int size, string name)
    {
        List<Receptionist> receptionists = await _unitOfWork.ReceptionistReadRepository.GetByCondition(r => r.Name.Contains(name.Trim()), page, size, false, "Gender").ToListAsync();
        List<ReceptionistGetDTO> receptionistGetDTOs = _mapper.Map<List<ReceptionistGetDTO>>(receptionists);

        for (int i = 0; i < receptionistGetDTOs.Count; i++)
        {
            receptionistGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(receptionists[i].Gender);
        }
        return receptionistGetDTOs;
    }

    public async Task<ReceptionistGetDTO> GetReceptionistBySeriaNumberAsync(string seriaNumber)
    {
        Receptionist receptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.SeriaNumber == seriaNumber.ToUpper(), false, "Gender");
        if (receptionist is null) throw new NotFoundException("Receptionist Not found");

        ReceptionistGetDTO receptionistGetDTO = _mapper.Map<ReceptionistGetDTO>(receptionist);
        receptionistGetDTO.GenderDTO = _mapper.Map<GenderDTO>(receptionist.Gender);

        return receptionistGetDTO;
    }

    public async Task CreateReceptionistAsync(ReceptionistPostDTO receptionistPostDTO)
    {
        Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.SeriaNumber == receptionistPostDTO.SeriaNumber.ToUpper(), false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this seria number");

        Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.SeriaNumber == receptionistPostDTO.SeriaNumber.ToUpper(), false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this Seria Number");

        baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.Email == receptionistPostDTO.Email.ToLower(), false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this email");

        baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Email == receptionistPostDTO.Email.ToLower(), false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this Email");

        baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.VOEN == receptionistPostDTO.VOEN, false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this VOEN");

        baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.VOEN == receptionistPostDTO.VOEN, false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this VOEN");

        AppUser baseUser = await _userManager.FindByNameAsync(receptionistPostDTO.SeriaNumber.ToUpper());
        if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to seria number entered, please contact admin or moderator");

        baseUser = await _userManager.FindByEmailAsync(receptionistPostDTO.Email);
        if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to email entered, please contact admin or moderator");

        var roleGetDTO = await _roleService.GetRoleByNameAsync(Roles.Receptions.ToString());
        UserPostDTO userPostDTO = new() { Fullname = receptionistPostDTO.Name + receptionistPostDTO.Surname, UserName = receptionistPostDTO.SeriaNumber.ToUpper(), Email = receptionistPostDTO.Email.ToLower(), Password = receptionistPostDTO.Name + receptionistPostDTO.SeriaNumber.ToUpper() + "!", ConfirmPassword = receptionistPostDTO.Name + receptionistPostDTO.SeriaNumber.ToUpper() + "!", RoleIdStr = roleGetDTO.Id };


        Receptionist receptionist = _mapper.Map<Receptionist>(receptionistPostDTO);
        receptionist.Email = receptionistPostDTO.Email.ToLower();
        receptionist.SeriaNumber = receptionistPostDTO.SeriaNumber.ToUpper();
        receptionist.GenderId = Guid.Parse(receptionistPostDTO.GenderIdStr);

        await _userService.CreateUserAsync(userPostDTO);
        await _unitOfWork.ReceptionistWriteRepository.CreateAsync(receptionist);
        await _unitOfWork.SaveAsync();
    }
    public async Task UpdateReceptionistAsync(ReceptionistPutDTO receptionistPutDTO)
    {
        Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.Id == Guid.Parse(receptionistPutDTO.IdStr) && !r.IsDeleted, false);        
        if (baseReceptionist is null) throw new NotFoundException("Not found");

        Receptionist baseReceptionistCopy = baseReceptionist;

        AppUser user = await _userManager.FindByNameAsync(baseReceptionistCopy.SeriaNumber);
        if (user is null) throw new NotFoundException("User Not found");

        if (receptionistPutDTO.SeriaNumber.ToUpper() != baseReceptionistCopy.SeriaNumber)
        {
            baseReceptionistCopy = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.SeriaNumber == receptionistPutDTO.SeriaNumber.ToUpper(), false);
            if (baseReceptionistCopy is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionistCopy.Id}) already registered with this Seria Number");

            Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.SeriaNumber == receptionistPutDTO.SeriaNumber.ToUpper(), false);
            if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this Seria Number");

            AppUser baseUser = await _userManager.FindByNameAsync(receptionistPutDTO.SeriaNumber.ToUpper());
            if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to seria number entered, please contact admin or moderator");

            user.UserName = receptionistPutDTO.SeriaNumber.ToUpper();
        }

        baseReceptionistCopy = baseReceptionist;

        if (receptionistPutDTO.Email.ToLower() != baseReceptionistCopy.Email)
        {
            baseReceptionistCopy = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.Email == receptionistPutDTO.Email.ToLower(), false);
            if (baseReceptionistCopy is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionistCopy.Id}) already registered with this Email");

            Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Email == receptionistPutDTO.Email.ToLower(), false);
            if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this Email");

            AppUser baseUser = await _userManager.FindByEmailAsync(receptionistPutDTO.Email);
            if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to email entered, please contact admin or moderator");

            user.Email = receptionistPutDTO.Email.ToLower();
        }

        baseReceptionistCopy = baseReceptionist;

        if (receptionistPutDTO.VOEN != baseReceptionistCopy.VOEN)
        {
            baseReceptionistCopy = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.VOEN == receptionistPutDTO.VOEN, false);
            if (baseReceptionistCopy is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseReceptionistCopy.Id}) already registered with this VOEN");

            Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.VOEN == receptionistPutDTO.VOEN, false);
            if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this VOEN");
        }

        Receptionist receptionist = _mapper.Map<Receptionist>(receptionistPutDTO);
        receptionist.SeriaNumber = receptionistPutDTO.SeriaNumber.ToUpper();
        receptionist.Email = receptionistPutDTO.Email.ToLower();
        receptionist.Id = Guid.Parse(receptionistPutDTO.IdStr);
        receptionist.GenderId = Guid.Parse(receptionistPutDTO.GenderIdStr);
        receptionist.IsDeleted = baseReceptionist.IsDeleted;
        receptionist.CreatedDate = baseReceptionist.CreatedDate;
       
        _unitOfWork.ReceptionistWriteRepository.Update(receptionist);
        
        IdentityResult identityResult = await _userManager.UpdateAsync(user);
        if (!identityResult.Succeeded)
        {
            string errors = string.Empty;
            int count = 0;
            foreach (var error in identityResult.Errors)
            {
                errors += count != 0 ? $",{error.Description}" : $"{error.Description}";
                count++;
            }
            throw new UserUpdateFailException(errors);
        }

        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteReceptionistAsync(string id)
    {
        Receptionist receptionist = await _unitOfWork.ReceptionistReadRepository.GetByIdAsync(Guid.Parse(id));
        if (receptionist is null) throw new NotFoundException("Not found");
        if (receptionist.IsDeleted) throw new AlreadyDeActiveException("Receptionist already Deactive");

        AppUser user = await _userManager.FindByNameAsync(receptionist.SeriaNumber);
        if (user is not null)
        {
            user.IsDeleted = true;
        }

        receptionist.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteReceptionistAsync(string id)
    {
        Receptionist receptionist = await _unitOfWork.ReceptionistReadRepository.GetByIdAsync(Guid.Parse(id));
        if (receptionist is null) throw new NotFoundException("Not found");

        _unitOfWork.ReceptionistWriteRepository.Delete(receptionist);
        await _unitOfWork.SaveAsync();
    }

}
