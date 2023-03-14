using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class RoomReadRepository : ReadRepository<Room>, IRoomReadRepository
{
    public RoomReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
