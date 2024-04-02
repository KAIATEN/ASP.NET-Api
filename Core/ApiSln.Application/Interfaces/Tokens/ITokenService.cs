﻿using ApiSln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Interfaces.Tokens
{
	public interface ITokenService
	{
		Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
		string GenerateRefreshToken();
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
	}
}
