using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services;

namespace Todo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService _service;
		public TodoController(ITodoService service)
		{
			_service = service;
		}
		[HttpGet("")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _service.GetAll());
		}
	}
}
