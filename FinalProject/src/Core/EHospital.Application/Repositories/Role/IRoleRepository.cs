using EHospital.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace EHospital.Application.Repositories;

public interface IRoleRepository
{
    IQueryable<IdentityRole> GetAllRole();
    IQueryable<IdentityRole> GetRoleByCondition(Expression<Func<IdentityRole, bool>> expression, bool isTracking = true);
    Task<IdentityRole> GetSingleRoleByConditionAsync(Expression<Func<IdentityRole, bool>> expression, bool isTracking = true);
    Task<IdentityRole> GetRoleByIdAsync(string id);
}
