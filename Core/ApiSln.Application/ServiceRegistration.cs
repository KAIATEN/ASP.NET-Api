using ApiSln.Application.Bases;
using ApiSln.Application.Behaviors;
using ApiSln.Application.Exceptions;
using ApiSln.Application.Features.Products.Rules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application
{
	public static class ServiceRegistration
	{
		public static void AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));
			services.AddTransient<ExceptionMiddleware>();
			services.AddValidatorsFromAssembly(assembly);
			ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
			services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

		}
		public static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
		{
			var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
			foreach (var item in types)
			{
				services.AddTransient(item);
			}
			return services;
		}
	}

}
