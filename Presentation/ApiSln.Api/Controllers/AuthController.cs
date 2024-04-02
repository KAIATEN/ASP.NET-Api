﻿using ApiSln.Application.Features.Auth.Commands.Register;
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
	}
}
