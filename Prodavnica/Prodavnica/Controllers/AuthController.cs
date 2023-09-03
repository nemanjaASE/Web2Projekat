using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prodavnica.Dto;
using Prodavnica.Interfaces.IService;

namespace Prodavnica.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _service;

		public AuthController(IAuthService service)
		{
			_service = service;
		}

		//POST api/auth
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Post([FromBody] LoginDTO loginDto)
		{
			string token = await _service.Login(loginDto);

			if (token == null)
			{
				return BadRequest();
			}

			return Ok(token);
		}
	}
}
