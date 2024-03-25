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
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			Faker faker = new Faker("tr");
			Product product1 = new Product()
			{
				Id = Guid.Parse("95CE32B1-AB53-4898-B95B-1E13C8D17F6D"),
				Title = faker.Commerce.ProductName(),
				Description = faker.Commerce.ProductDescription(),
				BrandId = Guid.Parse("6E3E8ED0-1300-4DFA-8855-25724576C837"),
				Discount = faker.Random.Decimal(0, 8),
				CreateDate = DateTime.Now,
				Price = faker.Finance.Amount(100, 1000),
			};
			Product product2 = new Product()
			{
				Id = Guid.Parse("201E8FC5-4C29-4045-82E1-7CC418311594"),
				Title = faker.Commerce.ProductName(),
				Description = faker.Commerce.ProductDescription(),
				BrandId = Guid.Parse("7E7ED1A0-670F-4B2F-8E55-E79F6F71ACA6"),
				Discount = faker.Random.Decimal(0, 8),
				CreateDate = DateTime.Now,
				Price = faker.Finance.Amount(100, 1000),
			};
			builder.HasData(product1, product2);
		}
	}
}
