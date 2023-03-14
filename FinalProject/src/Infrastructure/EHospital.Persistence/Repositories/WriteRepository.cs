using EHospital.Application.Repositories;
using EHospital.Domain.Entities.Common;
using EHospital.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
{
    private readonly EHospitalDbContext _context;

    public WriteRepository(EHospitalDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task CreateRangeAsync(ICollection<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public void DeleteRange(ICollection<T> entities)
    {
        Table.RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }


}
