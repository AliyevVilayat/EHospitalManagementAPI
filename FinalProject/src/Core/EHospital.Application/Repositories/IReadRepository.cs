using EHospital.Domain.Entities.Common;
using System.Linq.Expressions;

namespace EHospital.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity, new()
{
    IQueryable<T> GetAll(bool isTracking = true, params string[] includes);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression,bool isTracking = true, params string[] includes);
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression,int page,int size ,bool isTracking = true, params string[] includes);
    Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes);
    Task<T> GetByIdAsync(Guid id,params string[] includes);
    Task<int> GetDataCountAsync();
}
