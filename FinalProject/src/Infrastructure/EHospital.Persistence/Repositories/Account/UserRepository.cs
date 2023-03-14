using EHospital.Application.Repositories;
using EHospital.Domain.Entities.Identity;
using EHospital.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHospital.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EHospitalDbContext _context;

    public UserRepository(EHospitalDbContext context)
    {
        _context = context;
    }

    public IQueryable<AppUser> GetAllUser()
    {
        var query = _context.Users.AsQueryable().AsNoTracking();
        return query;
    }

    public IQueryable<AppUser> GetUserByCondition(Expression<Func<AppUser, bool>> expression, bool isTracking = true)
    {
        var query = _context.Users.Where(expression);
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public async Task<AppUser> GetSingleUserByConditionAsync(Expression<Func<AppUser, bool>> expression, bool isTracking = true)
    {
        var query = _context.Users.AsQueryable();      
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }
        AppUser? user = await query.FirstOrDefaultAsync(expression);
        return user;
    }

    public async Task<AppUser> GetUserByIdAsync(string id)
    {
        AppUser? user = await _context.Users.FindAsync(id);
        return user;
    }
}
