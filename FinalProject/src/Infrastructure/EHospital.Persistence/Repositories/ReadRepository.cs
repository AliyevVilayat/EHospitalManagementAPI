using EHospital.Application.Repositories;
using EHospital.Domain.Entities.Common;
using EHospital.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHospital.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
{
    private readonly EHospitalDbContext _context;

    public ReadRepository(EHospitalDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool isTracking = true, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
    {
        var query = Table.Where(expression).AsQueryable();
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, int page, int size, bool isTracking = true, params string[] includes)
    {
        var query = Table.Where(expression).Skip(page * size).Take(size);
        if (!isTracking)
        {
            query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression, bool isTracking = true, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        T? entity = await query.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task<T> GetByIdAsync(Guid id, params string[] includes)
    {
        var query = Table.AsQueryable();
        if (includes is not null && includes.Length > 0)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        T? entity = await query.FirstOrDefaultAsync(t => t.Id == id);
        return entity;
    }

    public async Task<int> GetDataCountAsync()
    {
        int count = await Table.CountAsync();
        return count;
    }


}
