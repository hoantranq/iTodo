using iTodo.Domain.Common;

namespace iTodo.Domain.Entities;

public class Item : EntityBase<Guid>
{
    public string? Title { get; set; }
    public bool IsDone { get; set; }
}

