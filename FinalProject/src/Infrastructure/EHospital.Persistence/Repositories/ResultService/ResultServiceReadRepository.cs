using EHospital.Application.Repositories;
using EHospital.Domain.Entities;
using EHospital.Persistence.Contexts;

namespace EHospital.Persistence.Repositories;

public class ResultServiceReadRepository : ReadRepository<ResultService>, IResultServiceReadRepository
{
    public ResultServiceReadRepository(EHospitalDbContext context) : base(context)
    {
    }
}
