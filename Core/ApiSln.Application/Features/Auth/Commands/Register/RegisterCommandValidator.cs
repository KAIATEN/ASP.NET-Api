using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.Register
{
	public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
	{
		public RegisterCommandValidator()
		{
			RuleFor(x => x.FullName).NotEmpty().MaximumLength(70).MinimumLength(2).WithName("İsim Soyisim");
			RuleFor(x => x.Email).NotEmpty().MaximumLength(60).EmailAddress().MinimumLength(8).WithName("E-posta Adresi");
			RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(30).WithName("Şifre");
			RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(6).MaximumLength(30).Equal(x => x.Password).WithName("Şifreyi onayla");
		}
	}
}
