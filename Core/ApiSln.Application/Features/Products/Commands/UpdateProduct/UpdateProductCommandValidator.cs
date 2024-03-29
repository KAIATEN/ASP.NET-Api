using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
	{
		public UpdateProductCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty().NotNull();
			RuleFor(x => x.Title).NotEmpty().WithName("Başlık");
			RuleFor(x => x.Description).NotEmpty().WithName("Açıklama");
			RuleFor(x => x.BrandId).NotNull().NotEmpty().WithName("Marka");
			RuleFor(x => x.Price).GreaterThan(0).WithName("Fiyat");
			RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithName("indirim oranı");
			RuleFor(x => x.CategoryIds).NotEmpty().NotNull().Must(categories => categories.Any()).WithName("Kategoriler");
		}
	}
}
