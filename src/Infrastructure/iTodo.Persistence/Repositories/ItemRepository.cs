using iTodo.Application.Repositories;
using iTodo.Domain.Entities;
using iTodo.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace iTodo.Persistence.Repositories;

public class ItemRepository : RepositoryBase<Item>, IItemRepository
{
    private readonly AppDbContext _context;

	public ItemRepository(AppDbContext context) : base(context)
	{
        _context = context;
	}

    public async Task<Item> GetSingleItemByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var result = await _context.Items.FirstOrDefaultAsync(x => x.CreatedBy == username, cancellationToken) ?? null!;

        return result;
    }

    public async Task<List<Item>> GetAllItemsByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var result = await _context.Items.ToListAsync(cancellationToken) ?? null!;

        return result;
    }
}