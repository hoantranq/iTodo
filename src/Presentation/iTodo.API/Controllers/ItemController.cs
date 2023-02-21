using iTodo.Application.Features.ItemFeatures.CreateItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iTodo.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
	public async Task<ActionResult> CreateItem(CreateItemRequest createItemRequest, CancellationToken cancellationToken)
	{
        var response = await _mediator.Send(createItemRequest, cancellationToken);

		return Ok(response);
	}
}

