namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public sealed record class CreateItemResponse
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	public bool IsDone { get; set; }
	public DateTime? ModifiedOn { get; set; }
}