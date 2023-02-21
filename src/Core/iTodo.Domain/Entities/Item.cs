using iTodo.Domain.Common;

namespace iTodo.Domain.Entities;

public sealed class Item : EntityBase
{
    public string? Title { get; set; }
    public bool IsDone { get; set; } = false;
}

