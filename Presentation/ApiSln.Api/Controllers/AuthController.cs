using ApiSln.Application.Features.Auth.Commands.Login;
using ApiSln.Application.Features.Auth.Commands.RefreshToken;
using ApiSln.Application.Features.Auth.Commands.Register;
using ApiSln.Application.Features.Auth.Commands.Revoke;
using ApiSln.Application.Features.Auth.Commands.RevokeAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSln.Api.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMediator mediator;

		public AuthController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
		{
			await mediator.Send(registerCommandRequest);
			return StatusCode(StatusCodes.Status201Created);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
		{
			var response = await mediator.Send(loginCommandRequest);
			return StatusCode(StatusCodes.Status200OK, response);
		}
		[HttpPost]
		public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest refreshTokenCommandRequest)
		{
			var response = await mediator.Send(refreshTokenCommandRequest);
			return StatusCode(StatusCodes.Status200OK, response);
		}
		[HttpPost]
		public async Task<IActionResult> Revoke(RevokeCommandRequest revokeCommandRequest)
		{
			await mediator.Send(revokeCommandRequest);
			return StatusCode(StatusCodes.Status200OK);
		}
		[HttpPost]
		public async Task<IActionResult> RevokeAll()
		{
			await mediator.Send(new RevokeAllCommandRequest());
			return StatusCode(StatusCodes.Status200OK);
		}
	}
}
