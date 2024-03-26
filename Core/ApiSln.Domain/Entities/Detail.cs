using ApiSln.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities
{
	public class Detail : BaseEntity
	{
		public Detail() { }
		public Detail(string title, string description, Guid categoryId)
		{
			this.Title = title;
			this.Description = description;
			this.CategoryId = categoryId;
		}
		public string Title { get; set; }
		public string Description { get; set; }
		public Guid CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
