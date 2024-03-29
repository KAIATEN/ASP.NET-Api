using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.DeleteProduct
{
	public class DeleteProductCommandRequest : IRequest
	{
		public Guid Id { get; set; }
	}
}
