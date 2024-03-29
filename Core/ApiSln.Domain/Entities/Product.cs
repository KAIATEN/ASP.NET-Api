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
		public Product()
		{

		}
		public Product(string title, string description, decimal price, decimal discount, Guid brandId)
		{
			this.Title = title;
			this.Description = description;
			this.Price = price;
			this.Discount = discount;
			this.BrandId = brandId;
		}
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public Guid BrandId { get; set; }
		public Brand Brand { get; set; }
		public ICollection<ProductCategory> ProductCategories { get; set; }
	}
}
