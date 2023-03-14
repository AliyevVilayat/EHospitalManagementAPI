using AutoMapper;
using EHospital.Application;
using EHospital.Application.DTOs;
using EHospital.Application.Exceptions;
using EHospital.Application.Services;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Services;

public class RoomService : IRoomService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IMapper mapper,IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<RoomGetDTO>> GetAllRoomAsync()
    {
        List<Room> rooms = await _unitOfWork.RoomReadRepository.GetAll(false, "Service").ToListAsync();
        List<RoomGetDTO> roomGetDTOs = _mapper.Map<List<RoomGetDTO>>(rooms);
        for (int i = 0; i < roomGetDTOs.Count; i++)
        {
            roomGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(rooms[i].Service);
        }
        return roomGetDTOs;
    }

    public async Task<List<RoomGetDTO>> GetAllActiveRoomAsync()
    {
        List<Room> rooms = await _unitOfWork.RoomReadRepository.GetByCondition(r => r.IsDeleted == false, false, "Service").ToListAsync();
        List<RoomGetDTO> roomGetDTOs = _mapper.Map<List<RoomGetDTO>>(rooms);
        for (int i = 0; i < roomGetDTOs.Count; i++)
        {
            roomGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(rooms[i].Service);
        }
        return roomGetDTOs;
    }

    public async Task<List<RoomGetDTO>> GetAllEmptyRoomAsync()
    {
        List<Room> rooms = await _unitOfWork.RoomReadRepository.GetByCondition(r => r.IsEmpty == true && r.IsDeleted==false, false, "Service").ToListAsync();
        List<RoomGetDTO> roomGetDTOs = _mapper.Map<List<RoomGetDTO>>(rooms);
        for (int i = 0; i < roomGetDTOs.Count; i++)
        {
            roomGetDTOs[i].ServiceGetDTO = _mapper.Map<ServiceGetDTO>(rooms[i].Service);
        }
        return roomGetDTOs;
    }

    public async Task<RoomGetDTO> GetRoomByCodeAsync(string code)
    {
        Room room = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r => r.RoomCode == code, false, "Service");
        if (room is null) throw new NotFoundException("Room Not found");

        RoomGetDTO roomGetDTO = _mapper.Map<RoomGetDTO>(room);
        roomGetDTO.ServiceGetDTO = _mapper.Map<ServiceGetDTO>(room.Service);
        return roomGetDTO;
    }

    public async Task<RoomGetDTO> GetRoomByIdAsync(string id)
    {
        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(Guid.Parse(id), "Service");
        if (room is null) throw new NotFoundException("Room Not found");

        RoomGetDTO roomGetDTO = _mapper.Map<RoomGetDTO>(room);
        roomGetDTO.ServiceGetDTO = _mapper.Map<ServiceGetDTO>(room.Service);
        return roomGetDTO;
    }

    public async Task CreateRoomAsync(RoomPostDTO roomPostDTO)
    {      
        Room baseroom = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r => r.RoomCode == roomPostDTO.RoomCode, false);
        if (baseroom is not null) throw new AlreadyRegisteredException($"Room(Id:{baseroom.Id}) already registered with this Room Code");

        Room room = _mapper.Map<Room>(roomPostDTO);
        await _unitOfWork.RoomWriteRepository.CreateAsync(room);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateRoomAsync(RoomPutDTO roomPutDTO)
    {
        Room baseroom = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r => r.Id == Guid.Parse(roomPutDTO.IdStr) && !r.IsDeleted, false);
        if (baseroom is null) throw new NotFoundException("Room Not found");
        if (baseroom.RoomCode != roomPutDTO.RoomCode)
        {
            baseroom = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r => r.RoomCode == roomPutDTO.RoomCode, false);
            if (baseroom is not null) throw new AlreadyRegisteredException($"Room(Id:{baseroom.Id}) already registered with this Room Code");
        }
        baseroom = await _unitOfWork.RoomReadRepository.GetSingleByConditionAsync(r => r.Id == Guid.Parse(roomPutDTO.IdStr), false);

        Room room = _mapper.Map<Room>(roomPutDTO);
        room.Id = Guid.Parse(roomPutDTO.IdStr);
        room.IsDeleted = baseroom.IsDeleted;
        room.CreatedDate = baseroom.CreatedDate;

        _unitOfWork.RoomWriteRepository.Update(room);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteRoomAsync(string id)
    {
        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(Guid.Parse(id));
        if (room is null) throw new NotFoundException("Room Not found");
        if (room.IsDeleted) throw new AlreadyDeActiveException("Room already Deactive");

        room.IsDeleted = true;
        await _unitOfWork.RoomWriteRepository.SaveAsync();
    }

    public async Task HardDeleteRoomAsync(string id)
    {
        Room room = await _unitOfWork.RoomReadRepository.GetByIdAsync(Guid.Parse(id));
        if (room is null) throw new NotFoundException("Room Not found");

        _unitOfWork.RoomWriteRepository.Delete(room);
        await _unitOfWork.SaveAsync();
    }
}
