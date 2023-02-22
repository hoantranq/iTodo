using iTodo.Domain.Common;

namespace iTodo.Application.Repositories;

public interface IRepositoryBase<T> where T : EntityBase
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
}