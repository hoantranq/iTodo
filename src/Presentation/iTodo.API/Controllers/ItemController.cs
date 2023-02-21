using Microsoft.AspNetCore.Mvc;

namespace iTodo.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemController : ControllerBase
{

	public ItemController()
	{

	}

	[HttpGet]
	public async Task<IActionResult> GetItems()
	{
		var items = new List<string>
		{
			"Item 1", "Item 2"
		};

		return Ok(await Task.FromResult(items));
	}
}

