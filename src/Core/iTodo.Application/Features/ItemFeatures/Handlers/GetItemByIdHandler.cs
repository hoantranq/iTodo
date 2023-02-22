using AutoMapper;
using iTodo.Application.Common.Exceptions;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Application.Features.ItemFeatures.Queries;
using iTodo.Application.Repositories;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Handlers;

public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ItemResponseDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetItemByIdHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<ItemResponseDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);

        if (item == null)
        {
            throw new NotFoundException("No available item was found");
        }

        var response = _mapper.Map<ItemResponseDto>(item);

        return response;
    }
}