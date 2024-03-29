using ApiSln.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.EntityConfigurations
{
	public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
	{
		public void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			builder.HasKey(x => new { x.ProductId, x.CategoryId });
			builder.HasOne(p => p.Product).WithMany(pc => pc.ProductCategories).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(p => p.Category).WithMany(pc => pc.ProductCategories).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);

		}
	}
}
