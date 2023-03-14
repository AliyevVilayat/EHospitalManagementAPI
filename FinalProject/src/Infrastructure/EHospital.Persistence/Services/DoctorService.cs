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

public class DoctorService : IDoctorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly UserManager<AppUser> _userManager;
    
    public DoctorService(IMapper mapper, IUserService userService,  IRoleService roleService, IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _userService = userService;
        _roleService = roleService;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }


    public async Task<List<DoctorGetDTO>> GetAllDoctorsAsync()
    {
        List<Doctor> doctors = await _unitOfWork.DoctorReadRepository.GetAll(false, "Gender", "Field").ToListAsync();
        List<DoctorGetDTO> doctorGetDTOs = _mapper.Map<List<DoctorGetDTO>>(doctors);

        for (int i = 0; i < doctorGetDTOs.Count; i++)
        {
            doctorGetDTOs[i].FieldDoctorGetDTO = _mapper.Map<FieldDoctorGetDTO>(doctors[i].Field);
            doctorGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(doctors[i].Gender);
        }
        return doctorGetDTOs;
    }

    public async Task<List<DoctorGetDTO>> GetAllActiveDoctorsAsync()
    {
        List<Doctor> doctors = await _unitOfWork.DoctorReadRepository.GetByCondition(d => d.IsDeleted == false, false, "Gender", "Field").ToListAsync();
        List<DoctorGetDTO> doctorGetDTOs = _mapper.Map<List<DoctorGetDTO>>(doctors);

        for (int i = 0; i < doctorGetDTOs.Count; i++)
        {
            doctorGetDTOs[i].FieldDoctorGetDTO = _mapper.Map<FieldDoctorGetDTO>(doctors[i].Field);
            doctorGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(doctors[i].Gender);
        }
        return doctorGetDTOs;
    }

    public async Task<DoctorGetDTO> GetDoctorByIdAsync(string id)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Id == Guid.Parse(id), true, "Gender", "Field");
        if (doctor is null) throw new NotFoundException("Doctor Not found");

        DoctorGetDTO doctorGetDTO = _mapper.Map<DoctorGetDTO>(doctor);
        doctorGetDTO.FieldDoctorGetDTO = _mapper.Map<FieldDoctorGetDTO>(doctor.Field);
        doctorGetDTO.GenderDTO = _mapper.Map<GenderDTO>(doctor.Gender);

        return doctorGetDTO;
    }

    public async Task<List<DoctorGetDTO>> GetDoctorByNameAsync(int page, int size, string name)
    {
        List<Doctor> doctors = await _unitOfWork.DoctorReadRepository.GetByCondition(d => d.Name.Contains(name.Trim()), page, size, false, "Gender", "Field").ToListAsync();
        List<DoctorGetDTO> doctorGetDTOs = _mapper.Map<List<DoctorGetDTO>>(doctors);
        for (int i = 0; i < doctorGetDTOs.Count; i++)
        {
            doctorGetDTOs[i].FieldDoctorGetDTO = _mapper.Map<FieldDoctorGetDTO>(doctors[i].Field);
            doctorGetDTOs[i].GenderDTO = _mapper.Map<GenderDTO>(doctors[i].Gender);
        }

        return doctorGetDTOs;
    }

    public async Task<DoctorGetDTO> GetDoctorBySeriaNumberAsync(string seriaNumber)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.SeriaNumber == seriaNumber.ToUpper(), false, "Gender", "Field");
        if (doctor is null) throw new NotFoundException("Not found");

        DoctorGetDTO doctorGetDTO = _mapper.Map<DoctorGetDTO>(doctor);
        doctorGetDTO.FieldDoctorGetDTO = _mapper.Map<FieldDoctorGetDTO>(doctor.Field);
        doctorGetDTO.GenderDTO = _mapper.Map<GenderDTO>(doctor.Gender);

        return doctorGetDTO;
    }

    public async Task CreateDoctorAsync(DoctorPostDTO doctorPostDTO)
    {
        Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.SeriaNumber == doctorPostDTO.SeriaNumber.ToUpper(), false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this seria number");

        Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.SeriaNumber == doctorPostDTO.SeriaNumber.ToUpper(), false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this Seria Number");

        baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Email == doctorPostDTO.Email.ToLower(), false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this email");

        baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.Email == doctorPostDTO.Email.ToLower(), false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this Email");

        baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.VOEN == doctorPostDTO.VOEN, false);
        if (baseDoctor is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctor.Id}) already registered with this VOEN");

        baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.VOEN == doctorPostDTO.VOEN, false);
        if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this VOEN");

        AppUser baseUser = await _userManager.FindByNameAsync(doctorPostDTO.SeriaNumber.ToUpper());
        if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to seria number entered, please contact admin or moderator");

        baseUser = await _userManager.FindByEmailAsync(doctorPostDTO.Email);
        if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to email entered, please contact admin or moderator");

        var roleGetDTO = await _roleService.GetRoleByNameAsync(Roles.Doctor.ToString());
        UserPostDTO userPostDTO = new() { Fullname = doctorPostDTO.Name + doctorPostDTO.Surname, UserName = doctorPostDTO.SeriaNumber.ToUpper(), Email = doctorPostDTO.Email.ToLower(), Password = doctorPostDTO.Name + doctorPostDTO.SeriaNumber.ToUpper() + "!", ConfirmPassword = doctorPostDTO.Name + doctorPostDTO.SeriaNumber.ToUpper() + "!", RoleIdStr = roleGetDTO.Id };

        Doctor doctor = _mapper.Map<Doctor>(doctorPostDTO);
        doctor.Email = doctorPostDTO.Email.ToLower();
        doctor.SeriaNumber = doctorPostDTO.SeriaNumber.ToUpper();
        doctor.GenderId = Guid.Parse(doctorPostDTO.GenderIdStr);
        doctor.FieldId = Guid.Parse(doctorPostDTO.FieldIdStr);

        await _userService.CreateUserAsync(userPostDTO);
        await _unitOfWork.DoctorWriteRepository.CreateAsync(doctor);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateDoctorAsync(DoctorPutDTO doctorPutDTO)
    {
        Doctor baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Id == Guid.Parse(doctorPutDTO.IdStr) && !d.IsDeleted, false);
        if (baseDoctor is null) throw new NotFoundException("Not found");

        Doctor baseDoctorCopy = baseDoctor;

        AppUser user = await _userManager.FindByNameAsync(baseDoctorCopy.SeriaNumber);
        if (user is null) throw new NotFoundException("User Not found");

        if (doctorPutDTO.SeriaNumber.ToUpper() != baseDoctorCopy.SeriaNumber)
        {
            baseDoctorCopy = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.SeriaNumber == doctorPutDTO.SeriaNumber.ToUpper(), false);
            if (baseDoctorCopy is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctorCopy.Id}) already registered with this Seria Number");

            Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.SeriaNumber == doctorPutDTO.SeriaNumber.ToUpper(), false);
            if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this Seria Number");

            AppUser baseUser = await _userManager.FindByNameAsync(doctorPutDTO.SeriaNumber.ToUpper());
            if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to seria number entered, please contact admin or moderator");

            user.UserName = doctorPutDTO.SeriaNumber.ToUpper();
        }

        baseDoctorCopy = baseDoctor;

        if (doctorPutDTO.Email.ToLower() != baseDoctorCopy.Email)
        {
            baseDoctorCopy = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Email == doctorPutDTO.Email.ToLower(), false);
            if (baseDoctorCopy is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctorCopy.Id}) already registered with this Email");

            Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.Email == doctorPutDTO.Email.ToLower(), false);
            if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this Email");

            AppUser baseUser = await _userManager.FindByEmailAsync(doctorPutDTO.Email);
            if (baseUser is not null) throw new AlreadyRegisteredException($"User(id:{baseUser.Id}) exists according to seria number entered, please contact admin or moderator");

            user.Email = doctorPutDTO.Email.ToLower();
        }

        baseDoctorCopy = baseDoctor;

        if (doctorPutDTO.VOEN != baseDoctorCopy.VOEN)
        {
            baseDoctorCopy = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.VOEN == doctorPutDTO.VOEN, false);
            if (baseDoctorCopy is not null) throw new AlreadyRegisteredException($"Doctor(Id:{baseDoctorCopy.Id}) already registered with this VOEN");

            Receptionist baseReceptionist = await _unitOfWork.ReceptionistReadRepository.GetSingleByConditionAsync(r => r.VOEN == doctorPutDTO.VOEN, false);
            if (baseReceptionist is not null) throw new AlreadyRegisteredException($"Receptionist(Id:{baseReceptionist.Id}) already registered with this VOEN");
        }

        baseDoctor = await _unitOfWork.DoctorReadRepository.GetSingleByConditionAsync(d => d.Id == Guid.Parse(doctorPutDTO.IdStr), false);

        Doctor doctor = _mapper.Map<Doctor>(doctorPutDTO);
        doctor.Id = Guid.Parse(doctorPutDTO.IdStr);
        doctor.Email = doctorPutDTO.Email.ToLower();
        doctor.SeriaNumber = doctorPutDTO.SeriaNumber.ToUpper();
        doctor.GenderId = Guid.Parse(doctorPutDTO.GenderIdStr);
        doctor.FieldId = Guid.Parse(doctorPutDTO.FieldIdStr);
        doctor.IsDeleted = baseDoctor.IsDeleted;
        doctor.CreatedDate = baseDoctor.CreatedDate;

        _unitOfWork.DoctorWriteRepository.Update(doctor);

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

    public async Task DeleteDoctorAsync(string id)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(Guid.Parse(id));
        if (doctor is null) throw new NotFoundException("Not found");
        if (doctor.IsDeleted) throw new AlreadyDeActiveException("Doctor already Deactive");

        AppUser user = await _userManager.FindByNameAsync(doctor.SeriaNumber);
        if (user is not null)
        {
            user.IsDeleted = true;
        }

        doctor.IsDeleted = true;
        await _unitOfWork.SaveAsync();
    }

    public async Task HardDeleteDoctorAsync(string id)
    {
        Doctor doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(Guid.Parse(id));
        if (doctor is null) throw new NotFoundException("Not found");

        _unitOfWork.DoctorWriteRepository.Delete(doctor);
        await _unitOfWork.SaveAsync();
    }
}
