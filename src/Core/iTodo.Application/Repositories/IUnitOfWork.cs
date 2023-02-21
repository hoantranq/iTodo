namespace iTodo.Application.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
}