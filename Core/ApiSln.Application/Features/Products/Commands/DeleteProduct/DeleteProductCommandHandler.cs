using ApiSln.Application.Bases;
using ApiSln.Application.Interfaces.AutoMapper;
using ApiSln.Application.Interfaces.UnitOfWorks;
using ApiSln.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
	{

		public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
		{

		}
		public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id);
			await unitOfWork.GetWriteRepository<Product>().DeleteAsync(product);
			await unitOfWork.SaveAsync();
			return Unit.Value;
		}
	}
}
