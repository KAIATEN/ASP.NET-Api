using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities
{
	public class Product : BaseEntity
	{
		public required string Title { get; set; }
		public required string Description { get; set; }
		public required decimal Price { get; set; }
		public required decimal Discount { get; set; }
		public required Guid BrandId { get; set; }
		public Brand Brand { get; set; }
		public ICollection<Category> Categories { get; set; }
	}
}
