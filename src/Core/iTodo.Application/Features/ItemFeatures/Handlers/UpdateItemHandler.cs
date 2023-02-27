using AutoMapper;
using iTodo.Application.Common.Exceptions;
using iTodo.Application.Features.ItemFeatures.Commands;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Application.Repositories;
using iTodo.Domain.Entities;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Handlers;

public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, ItemResponseDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateItemHandler(IItemRepository itemRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponseDto> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
    {
        // Checking if item exist in the database
        var itemFromDb = await _itemRepository.GetByIdAsync(command.Id, cancellationToken);

        if (itemFromDb == null)
        {
            throw new NotFoundException("No available item was found");
        }
        else
        {
            var updateItem = _mapper.Map<Item>(command);

            // Add aditional item information
            updateItem.ModifiedOn = DateTime.Now;
            updateItem.ModifiedBy = "ryan"; // Mock data for testing
            updateItem.IsDeleted = false;

            await _itemRepository.UpdateAsync(updateItem);

            await _unitOfWork.SaveAsync(cancellationToken);

            return await Task.FromResult(_mapper.Map<ItemResponseDto>(updateItem));
        }
    }
}