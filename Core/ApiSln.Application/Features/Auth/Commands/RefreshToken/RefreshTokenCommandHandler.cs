using ApiSln.Application.Bases;
using ApiSln.Application.Features.Auth.Rules;
using ApiSln.Application.Interfaces.AutoMapper;
using ApiSln.Application.Interfaces.Tokens;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.RefreshToken
{
	public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
	{
		private readonly UserManager<User> userManager;
		private readonly ITokenService tokenService;
		private readonly AuthRules authRules;
		public RefreshTokenCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
		{
			this.userManager = userManager;
			this.tokenService = tokenService;
			this.authRules = authRules;
		}

		public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
		{
			ClaimsPrincipal principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
			string email = principal.FindFirstValue(ClaimTypes.Email);
			User user = await userManager.FindByEmailAsync(email);
			IList<string> roles = await userManager.GetRolesAsync(user);
			await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);
			JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
			string newRefreshToken = tokenService.GenerateRefreshToken();
			user.RefreshToken = newRefreshToken;
			await userManager.UpdateAsync(user);
			return new()
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
				RefreshToken = newRefreshToken,
			};
		}
	}
}
