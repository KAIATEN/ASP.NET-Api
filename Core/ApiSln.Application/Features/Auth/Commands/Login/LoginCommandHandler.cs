using ApiSln.Application.Bases;
using ApiSln.Application.Features.Auth.Rules;
using ApiSln.Application.Interfaces.AutoMapper;
using ApiSln.Application.Interfaces.Tokens;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.Login
{
	public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
	{
		private readonly AuthRules authRules;
		private readonly ITokenService tokenService;
		private readonly IConfiguration configuration;
		private readonly UserManager<User> userManager;

		public LoginCommandHandler(IMapper mapper, AuthRules authRules, ITokenService tokenService, IConfiguration configuration, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
		{
			this.authRules = authRules;
			this.tokenService = tokenService;
			this.configuration = configuration;
			this.userManager = userManager;
		}

		public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
		{
			User user = await userManager.FindByEmailAsync(request.Email);
			bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);
			await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);
			IList<string> roles = await userManager.GetRolesAsync(user);
			JwtSecurityToken token = await tokenService.CreateToken(user, roles);
			string refreshToken = tokenService.GenerateRefreshToken();
			_ = int.TryParse(configuration["JWT:RefreshTokenValidityDays"], out int refreshTokenValidityDays);
			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityDays);
			await userManager.UpdateAsync(user);
			await userManager.UpdateSecurityStampAsync(user);
			string _token = new JwtSecurityTokenHandler().WriteToken(token);
			await userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);
			return new()
			{
				Expiration = token.ValidTo,
				Token = _token,
				RefreshToken = refreshToken
			};
		}
	}
}
