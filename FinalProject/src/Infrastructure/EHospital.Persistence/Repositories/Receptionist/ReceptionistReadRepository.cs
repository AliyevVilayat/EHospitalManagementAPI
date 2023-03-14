using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class ReceptionistReadRepository : ReadRepository<Receptionist>, IReceptionistReadRepository
{
    public ReceptionistReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
