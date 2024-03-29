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
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
	{
		private readonly IUnitOfWork unitOfWork;

		public CreateProductCommandHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
		public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
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
		}
	}
}
