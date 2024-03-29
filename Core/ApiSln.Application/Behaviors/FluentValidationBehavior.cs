﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Behaviors
{
	public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> validator;

		public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
		{
			this.validator = validator;
		}
		public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var context = new ValidationContext<TRequest>(request);
			var failtures = validator.Select(v => v.Validate(context)).SelectMany(result => result.Errors).GroupBy(x => x.ErrorMessage).Select(x => x.First()).Where(l => l != null).ToList();
			if (failtures.Any())
			{
				throw new ValidationException(failtures);
			}
			return next();
		}
	}
}
