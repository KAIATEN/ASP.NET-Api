using ApiSln.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Persistence.EntityConfigurations
{
	public class BrandConfiguration : IEntityTypeConfiguration<Brand>
	{
		public void Configure(EntityTypeBuilder<Brand> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(200);
			Faker faker = new Faker("tr");
			Brand brand1 = new Brand()
			{
				Id = Guid.Parse("6E3E8ED0-1300-4DFA-8855-25724576C837"),
				Name = faker.Commerce.Department(),
				CreateDate = DateTime.Now,
			};
			Brand brand2 = new Brand()
			{
				Id = Guid.Parse("3D403E8F-6634-47C1-869E-803E27EA5C50"),
				Name = faker.Commerce.Department(),
				CreateDate = DateTime.Now,
			};
			Brand brand3 = new Brand()
			{
				Id = Guid.Parse("7E7ED1A0-670F-4B2F-8E55-E79F6F71ACA6"),
				Name = faker.Commerce.Department(),
				CreateDate = DateTime.Now,
			};
			builder.HasData(brand1, brand2, brand3);
		}
	}
}
