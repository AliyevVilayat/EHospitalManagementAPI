using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class RoomWriteRepository : WriteRepository<Room>, IRoomWriteRepository
{
    public RoomWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
