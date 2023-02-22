using AutoMapper;
using iTodo.Application.Common.Exceptions;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Application.Features.ItemFeatures.Queries;
using iTodo.Application.Repositories;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Handlers;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemResponseDto>>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetAllItemsHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemResponseDto>> Handle(GetAllItemsQuery request,
        CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync(cancellationToken);

        if (items == null)
        {
            throw new NotFoundException("No available item was found");
        }

        var response = _mapper.Map<IEnumerable<ItemResponseDto>>(items);

        return response;
    }
}