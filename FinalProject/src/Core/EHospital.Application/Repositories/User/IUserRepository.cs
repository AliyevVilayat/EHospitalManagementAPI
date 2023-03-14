using EHospital.Domain.Entities.Identity;
using System.Linq.Expressions;

namespace EHospital.Application.Repositories;

public interface IUserRepository
{
    IQueryable<AppUser> GetAllUser();
    IQueryable<AppUser> GetUserByCondition(Expression<Func<AppUser, bool>> expression, bool isTracking = true);
    Task<AppUser> GetSingleUserByConditionAsync(Expression<Func<AppUser, bool>> expression, bool isTracking = true);
    Task<AppUser> GetUserByIdAsync(string id);
}
