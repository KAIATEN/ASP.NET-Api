using ApiSln.Persistence.Context;
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

		}
	}
}
