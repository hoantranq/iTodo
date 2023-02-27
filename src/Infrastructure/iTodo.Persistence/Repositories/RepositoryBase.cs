using iTodo.Application.Repositories;
using iTodo.Domain.Common;
using iTodo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace iTodo.Persistence.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
    private readonly AppDbContext _context;

    public RepositoryBase(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        var model = _context.Entry(entity);
        // state is now Modified. This supercedes the AsNoTracking()
        model.State = EntityState.Modified;
        // state is now Unchanged here; it's now part of the tracking
        await Task.FromResult(_context.Update(entity));
    }

    public async Task DeleteAsync(T entity)
    {
        entity.IsDeleted = true; // Soft Delete
        await Task.FromResult(_context.Update(entity));
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken) ?? null!;

        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);

        return result;
    }
}