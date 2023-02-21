using AutoMapper;
using iTodo.Application.Repositories;
using iTodo.Domain.Entities;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public sealed class CreateItemHandler : IRequestHandler<CreateItemRequest, CreateItemResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IItemRepository _itemRepository;

    public CreateItemHandler(IMapper mapper, IUnitOfWork unitOfWork, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _itemRepository = itemRepository;
    }

    public async Task<CreateItemResponse> Handle(CreateItemRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        item.CreatedOn = DateTime.Now;
        item.CreatedBy = "test_user";

        await _itemRepository.CreateAsync(item);

        await _unitOfWork.SaveAsync(cancellationToken);

        return _mapper.Map<CreateItemResponse>(item);
    }
}