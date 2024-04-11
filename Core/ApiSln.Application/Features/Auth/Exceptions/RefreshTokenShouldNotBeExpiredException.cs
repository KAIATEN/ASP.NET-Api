using ApiSln.Application.Bases;

namespace ApiSln.Application.Features.Auth.Exceptions
{
	public class RefreshTokenShouldNotBeExpiredException : BaseExcepiton
	{
		public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Tekrar giriş yapınız")
		{

		}
	}
}
