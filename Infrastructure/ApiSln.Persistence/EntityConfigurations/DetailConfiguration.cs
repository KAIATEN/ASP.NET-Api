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
	public class DetailConfiguration : IEntityTypeConfiguration<Detail>
	{
		public void Configure(EntityTypeBuilder<Detail> builder)
		{
			Faker faker = new Faker("tr");
			Detail detail1 = new Detail()
			{
				Id = Guid.Parse("3B18453B-4F06-433B-AC95-7E933016216C"),
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(4),
				CategoryId = Guid.Parse("8765EF17-5245-4499-B6BD-BB428A1B0249"),
				CreateDate = DateTime.Now,
			};
			Detail detail2 = new Detail()
			{
				Id = Guid.Parse("D6F5AD11-C86E-4C9D-BA00-9F5C8685F455"),
				Title = faker.Lorem.Sentence(2),
				Description = faker.Lorem.Sentence(4),
				CategoryId = Guid.Parse("6EBED990-84E9-44FA-B36E-F124E14A0118"),
				CreateDate = DateTime.Now,
			};
			Detail detail3 = new Detail()
			{
				Id = Guid.Parse("1BA3F044-6632-486B-978F-7AEE1784FA83"),
				Title = faker.Lorem.Sentence(1),
				Description = faker.Lorem.Sentence(4),
				CategoryId = Guid.Parse("2DBC5F92-FA5C-4B2E-B6D2-B22CDE7A5E3A"),
				CreateDate = DateTime.Now,
			};
			builder.HasData(detail1, detail2, detail3);
		}
	}
}
