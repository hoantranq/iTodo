using AutoMapper;
using iTodo.Application.Common.Exceptions;
using iTodo.Application.Features.ItemFeatures.Commands;
using iTodo.Application.Features.ItemFeatures.Dtos;
using iTodo.Application.Repositories;
using iTodo.Domain.Entities;
using MediatR;

namespace iTodo.Application.Features.ItemFeatures.Handlers;

public class DeleteItemHandler : IRequestHandler<DeleteItemCommand, ItemResponseDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteItemHandler(IItemRepository itemRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponseDto> Handle(DeleteItemCommand command, CancellationToken cancellationToken)
    {
        // Checking if item exist in the database
        var itemFromDb = await _itemRepository.GetByIdAsync(command.Id, cancellationToken);

        if (itemFromDb == null)
        {
            throw new NotFoundException("No available item was found");
        }
        else
        {
            var itemToDelete = _mapper.Map<Item>(command);

            // Add aditional item information
            itemToDelete.ModifiedBy = "ryan"; // Mock data for testing
            itemToDelete.ModifiedOn = DateTime.Now;
            itemToDelete.IsDeleted = true;

            await _itemRepository.DeleteAsync(itemToDelete);

            await _unitOfWork.SaveAsync(cancellationToken);

            return await Task.FromResult(_mapper.Map<ItemResponseDto>(itemToDelete));
        }
    }
}