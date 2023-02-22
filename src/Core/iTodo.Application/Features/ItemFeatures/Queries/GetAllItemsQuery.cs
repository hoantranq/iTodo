using iTodo.Application.Features.ItemFeatures.Dtos;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Queries;

public class GetAllItemsQuery : IRequest<IEnumerable<ItemResponseDto>>
{
}