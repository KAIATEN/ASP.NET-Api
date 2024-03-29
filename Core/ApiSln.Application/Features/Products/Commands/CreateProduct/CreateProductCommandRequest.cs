using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Products.Commands.CreateProduct
{
	public class CreateProductCommandRequest : IRequest
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public Guid BrandId { get; set; }
		public IList<Guid> CategoryIds { get; set; }
	}
}
