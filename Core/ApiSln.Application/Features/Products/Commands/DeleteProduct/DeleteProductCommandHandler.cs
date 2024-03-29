using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}
		public async Task Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
			await unitOfWork.GetWriteRepository<Product>().DeleteAsync(product);
			await unitOfWork.SaveAsync();
		}
	}
}
