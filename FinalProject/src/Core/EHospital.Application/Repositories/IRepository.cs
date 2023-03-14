using EHospital.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
}
