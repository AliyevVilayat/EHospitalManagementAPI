using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class ResultServiceWriteRepository : WriteRepository<ResultService>, IResultServiceWriteRepository
{
    public ResultServiceWriteRepository(EHospitalDbContext context) : base(context)
    {
    }
}
