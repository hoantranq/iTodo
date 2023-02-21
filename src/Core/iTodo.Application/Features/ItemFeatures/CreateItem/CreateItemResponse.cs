namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public sealed record class CreateItemResponse
{
    public Guid Id { get; set; } = default!;

    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }
}