using ApiSln.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Mapper
{
	public static class ServiceRegistration
	{
		public static void AddCustomMapper(this IServiceCollection services)
		{
			services.AddSingleton<IMapper, AutoMapper.Mapper>();
		}
	}
}
