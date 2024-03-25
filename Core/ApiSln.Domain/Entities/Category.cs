using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities
{
	public class Category : BaseEntity
	{
		public Category()
		{

		}
		public Category(Guid parentId, string name, int priorty)
		{
			this.ParentId = parentId;
			this.Name = name;
			this.Priorty = priorty;
		}
		public required Guid ParentId { get; set; }
		public required string Name { get; set; }
		public required int Priorty { get; set; }
		public ICollection<Detail> Details { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
