using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities
{
	public class ProductCategory : IBaseEntity
	{
		public Guid ProductId { get; set; }
		public Guid CategoryId { get; set; }
		public Product Product { get; set; }
		public Category Category { get; set; }
	}
}
