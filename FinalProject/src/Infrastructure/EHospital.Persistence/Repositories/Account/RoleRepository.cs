using EHospital.Application.Repositories;
using EHospital.Domain.Entities.Identity;
using EHospital.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace EHospital.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly EHospitalDbContext _context;

    public RoleRepository(EHospitalDbContext context)
    {
        _context = context;
    }
    public IQueryable<IdentityRole> GetAllRole()
    {
        var query = _context.Roles.AsQueryable().AsNoTracking();
        return query;
    }

    public IQueryable<IdentityRole> GetRoleByCondition(Expression<Func<IdentityRole, bool>> expression, bool isTracking = true)
    {
        var query = _context.Roles.Where(expression);
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }
    public async Task<IdentityRole> GetSingleRoleByConditionAsync(Expression<Func<IdentityRole, bool>> expression, bool isTracking = true)
    {
        var query = _context.Roles.AsQueryable();
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        IdentityRole? role = await query.FirstOrDefaultAsync(expression);
        return role;
    }

    public async Task<IdentityRole> GetRoleByIdAsync(string id)
    {
        IdentityRole? role = await _context.Roles.FindAsync(id);
        return role;
    }    
}
