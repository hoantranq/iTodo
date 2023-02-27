using iTodo.Application.Features.ItemFeatures.Dtos;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Commands;

public class CreateItemCommand : IRequest<ItemResponseDto>
{
    public string? Title { get; set; }
}