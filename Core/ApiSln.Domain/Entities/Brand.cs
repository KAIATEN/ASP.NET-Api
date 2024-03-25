using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities
{
	public class Brand : BaseEntity
	{
		public Brand()
		{

		}
		public Brand(string name)
		{
			this.Name = name;
		}
		public required string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
