using EHospital.Domain.Entities.Common;

namespace EHospital.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    Task CreateAsync(T entity);
    Task CreateRangeAsync(ICollection<T> entities);
    void Update(T entity);
    void Delete(T entity);
    void DeleteRange(ICollection<T> entities);
    Task SaveAsync();
}
