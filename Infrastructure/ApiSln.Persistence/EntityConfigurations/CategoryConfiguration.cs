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
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			Category category1 = new Category()
			{
				Id = Guid.Parse("8765EF17-5245-4499-B6BD-BB428A1B0249"),
				Name = "Elektronik",
				Priorty = 1,
				ParentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				CreateDate = DateTime.Now,
			};
			Category category2 = new Category()
			{
				Id = Guid.Parse("2DBC5F92-FA5C-4B2E-B6D2-B22CDE7A5E3A"),
				Name = "Moda",
				Priorty = 2,
				ParentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
				CreateDate = DateTime.Now,
			};
			Category parent1 = new Category()
			{
				Id = Guid.Parse("6EBED990-84E9-44FA-B36E-F124E14A0118"),
				Name = "Bilgisayar",
				Priorty = 1,
				ParentId = Guid.Parse("8765EF17-5245-4499-B6BD-BB428A1B0249"),
				CreateDate = DateTime.Now,
			};
			Category parent2 = new Category()
			{
				Id = Guid.Parse("9E611FF4-2260-4BA8-932C-163C2ED4465E"),
				Name = "Kadın",
				Priorty = 1,
				ParentId = Guid.Parse("2DBC5F92-FA5C-4B2E-B6D2-B22CDE7A5E3A"),
				CreateDate = DateTime.Now,
			};
			builder.HasData(category1, category2, parent1, parent2);
		}
	}
}
