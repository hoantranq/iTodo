using iTodo.Domain.Entities;

namespace iTodo.Application.Repositories;

public interface IItemRepository : IRepositoryBase<Item>
{
    Task<Item> GetSingleItemByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<List<Item>> GetAllItemsByUsernameAsync(string username, CancellationToken cancellationToken);
}