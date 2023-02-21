namespace iTodo.Domain.Common;

public class EntityBase<T>
{
	public T Id { get; set; } = default!;

	public string? CreatedBy { get; set; }

	public string? UpdatedBy { get; set; }

	public DateTime? CreatedOn { get; set; }

	public DateTime? ModifiedOn { get; set; }
}

