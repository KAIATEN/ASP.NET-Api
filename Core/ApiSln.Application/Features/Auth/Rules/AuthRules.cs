﻿using ApiSln.Application.Bases;
using ApiSln.Application.Features.Auth.Exceptions;
using ApiSln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Rules
{
	public class AuthRules : BaseRules
	{
		public Task UserShouldNotBeExist(User? user)
		{
			if (user is not null)
			{
				throw new UserAlreadyExistException();
			}
			return Task.CompletedTask;
		}
	}
}
