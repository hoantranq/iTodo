using iTodo.Application.Features.ItemFeatures.Dtos;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Queries;

public class GetItemByIdQuery : IRequest<ItemResponseDto>
{
    public Guid Id { get; set; }
}