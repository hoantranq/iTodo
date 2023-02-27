namespace iTodo.Application.Features.ItemFeatures.Dtos;

public class ItemResponseDto
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public bool IsDone { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }
}