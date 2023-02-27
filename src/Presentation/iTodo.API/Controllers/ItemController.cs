using iTodo.Application.Features.ItemFeatures.Commands;
using iTodo.Application.Features.ItemFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iTodo.API.Controllers;

/// <summary>
/// Item Controller endpoint 
/// </summary>
/// <returns></returns>
[ApiController]
[Route("api/v1/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// An Item Controller constructor
    /// </summary>
    /// <returns></returns>
    public ItemController(IMediator mediator)
    {
        _mediator = (mediator ?? HttpContext.RequestServices.GetService<IMediator>())
                    ?? throw new ArgumentNullException(nameof(mediator));
    }

    /// <summary>
    /// An endpoint to get all items
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public async Task<ActionResult> GetAllItemsAsync()
    {
        var response = await _mediator.Send(new GetAllItemsQuery());

        return Ok(response);
    }

    /// <summary>
    /// An endpoint to get item by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetItemByIdAsync(Guid id)
    {
        var response = await _mediator.Send(new GetItemByIdQuery { Id = id });

        return Ok(response);
    }

    /// <summary>
    /// An endpoint to create new item
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> CreateItemAsync([FromBody] CreateItemCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }

    /// <summary>
    /// An endpoint to update existing item
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult> UpdateItemAsync([FromBody] UpdateItemCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }


    /// <summary>
    /// An endpoint to delete exisiting item
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<ActionResult> DeleteItemAsync([FromBody] DeleteItemCommand command)
    {
        var response = await _mediator.Send(command);

        return Ok(response);
    }
}