using AutoMapper;
using iTodo.Application.Features.ItemFeatures.Commands;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Application.Repositories;
using iTodo.Domain.Entities;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Handlers;

public class CreateItemHandler : IRequestHandler<CreateItemCommand, ItemResponseDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateItemHandler(IItemRepository itemRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponseDto> Handle(CreateItemCommand command, CancellationToken cancellationToken)
    {
        var newItem = _mapper.Map<Item>(command);

        // Add aditional item information
        newItem.CreatedBy = "ryan"; // Mock data for testing
        newItem.CreatedOn = DateTime.Now;
        newItem.IsDeleted = false;
        newItem.IsDone = false;


        await _itemRepository.CreateAsync(newItem);

        try
        {
            await _unitOfWork.SaveAsync(cancellationToken);
        }
        catch (System.Exception ex)
        {

            throw;
        }

        return await Task.FromResult(_mapper.Map<ItemResponseDto>(newItem));
    }
}