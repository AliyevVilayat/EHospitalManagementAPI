using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class ReceptionistWriteRepository : WriteRepository<Receptionist>, IReceptionistWriteRepository
{
    public ReceptionistWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
