using iTodo.Application.Features.ItemFeatures.Dtos;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Commands;

public class DeleteItemCommand : IRequest<ItemResponseDto>
{
    public Guid Id { get; set; }
}