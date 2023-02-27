using iTodo.Application.Features.ItemFeatures.Dtos;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Commands;

public class UpdateItemCommand : IRequest<ItemResponseDto>
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public bool IsDone { get; set; }

    public bool IsDeleted { get; set; }
}