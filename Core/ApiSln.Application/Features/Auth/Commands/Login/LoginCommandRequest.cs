using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.Login
{
	public class LoginCommandRequest : IRequest<LoginCommandResponse>
	{
		[DefaultValue("vaynezed@mail.com")]
		public string Email { get; set; }
		[DefaultValue("1234567")]
		public string Password { get; set; }
	}
}
