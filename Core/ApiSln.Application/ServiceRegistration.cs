using ApiSln.Application.Behaviors;
using ApiSln.Application.Exceptions;
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
		}
	}
}
