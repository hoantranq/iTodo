using MediatR;

namespace iTodo.Application.Features.ItemFeatures.CreateItem;

public sealed record CreateItemRequest(string? Title, bool IsDone) : IRequest<CreateItemResponse>;