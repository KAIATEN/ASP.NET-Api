using ApiSln.Application.Bases;
using ApiSln.Application.Features.Auth.Rules;
using ApiSln.Application.Interfaces.AutoMapper;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Commands.Revoke
{
	public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
	{
		private readonly UserManager<User> userManager;
		private readonly AuthRules authRules;
		public RevokeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, AuthRules authRules) : base(mapper, unitOfWork, httpContextAccessor)
		{
			this.userManager = userManager;
			this.authRules = authRules;
		}

		public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
		{
			User user = await userManager.FindByEmailAsync(request.Email);
			await authRules.EmailAddressShouldBeValid(user);
			user.RefreshToken = null;
			await userManager.UpdateAsync(user);
			return Unit.Value;
		}
	}
}
