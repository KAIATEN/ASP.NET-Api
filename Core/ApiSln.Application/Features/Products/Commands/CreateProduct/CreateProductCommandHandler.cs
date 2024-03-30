using ApiSln.Application.Features.Products.Rules;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, Unit>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ProductRules productRules;

		public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
		{
			this.unitOfWork = unitOfWork;
			this.productRules = productRules;
		}
		public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			List<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
			await productRules.ProductTitleMustNotBeSame(products, request.Title);

			Product product = new(request.Title, request.Description, request.Price, request.Discount, request.BrandId);
			await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
			if (await unitOfWork.SaveAsync() > 0)
			{
				foreach (var categoryId in request.CategoryIds)
				{
					await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
					{
						ProductId = product.Id,
						CategoryId = categoryId,
					});
				}
				await unitOfWork.SaveAsync();
			}
			return Unit.Value;
		}
	}
}
