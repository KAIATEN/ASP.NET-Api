﻿using ApiSln.Application.Interfaces.Repositories;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using ApiSln.Persistence.Context;
using ApiSln.Persistence.Repositories;
using ApiSln.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<APIDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
			services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddIdentityCore<User>(opt =>
			{
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 2;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.Password.RequireDigit = false;
				opt.SignIn.RequireConfirmedEmail = false;
			}).AddRoles<Role>().AddEntityFrameworkStores<APIDbContext>();
		}
	}
}
