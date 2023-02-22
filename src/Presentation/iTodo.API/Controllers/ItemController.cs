using iTodo.Application.Features.ItemFeatures.Queries;
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
        _mediator = (mediator ?? HttpContext.RequestServices.GetService<IMediator>())
                    ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult> CreateItemAsync(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(null!, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllItemsAsync()
    {
        var response = await _mediator.Send(new GetAllItemsQuery());

        return Ok(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetItemByIdAsync(Guid id)
    {
        var response = await _mediator.Send(new GetItemByIdQuery {Id = id});

        return Ok(response);
    }
}