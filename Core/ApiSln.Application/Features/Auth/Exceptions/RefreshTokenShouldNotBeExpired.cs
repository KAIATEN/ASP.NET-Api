using ApiSln.Application.Bases;

namespace ApiSln.Application.Features.Auth.Exceptions
{
	public class RefreshTokenShouldNotBeExpired : BaseExcepiton
	{
		public RefreshTokenShouldNotBeExpired() : base("Oturum süresi sona ermiştir. Tekrar giriş yapınız")
		{

		}
	}
}
