﻿using ApiSln.Application.Interfaces.AutoMapper;
using ApiSln.Application.Interfaces.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Bases
{
	public class BaseHandler
	{
		public readonly IMapper mapper;
		public readonly IUnitOfWork unitOfWork;
		public readonly IHttpContextAccessor httpContextAccessor;
		public readonly string userId;

		public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
		{
			this.mapper = mapper;
			this.unitOfWork = unitOfWork;
			this.httpContextAccessor = httpContextAccessor;
			userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
		}

	}
}
