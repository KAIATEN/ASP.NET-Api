using ApiSln.Application.Bases;
using ApiSln.Application.Features.Products.Exceptions;
using ApiSln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Rules
{
	public class ProductRules : BaseRules
	{
		public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
		{
			if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
			return Task.CompletedTask;
		}
	}
}
