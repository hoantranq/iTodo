using iTodo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iTodo.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; } = default!;
}