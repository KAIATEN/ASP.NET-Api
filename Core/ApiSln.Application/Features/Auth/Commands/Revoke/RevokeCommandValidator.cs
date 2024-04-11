using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.Revoke
{
	public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
	{
		public RevokeCommandValidator()
		{
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
		}
	}
}
