using ApiSln.Application.Bases;

namespace ApiSln.Application.Features.Auth.Exceptions
{
	public class EmailOrPasswordShouldNotBeInvalidException : BaseExcepiton
	{
		public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlış")
		{

		}
	}
}
