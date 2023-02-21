using MediatR;

namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public record CreateItemRequest(string? Title) : IRequest<CreateItemResponse>;