﻿// <auto-generated />
using System;
using ApiSln.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiSln.Persistence.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20240325202631_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiSln.Domain.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(3929),
                            Name = "Industrial"
                        },
                        new
                        {
                            Id = new Guid("3d403e8f-6634-47c1-869e-803e27ea5c50"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(4261),
                            Name = "Music, Beauty & Electronics"
                        },
                        new
                        {
                            Id = new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(4281),
                            Name = "Industrial, Books & Sports"
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7188),
                            Name = "Elektronik",
                            ParentId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Priorty = 1
                        },
                        new
                        {
                            Id = new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7191),
                            Name = "Moda",
                            ParentId = new Guid("11111111-1111-1111-1111-111111111111"),
                            Priorty = 2
                        },
                        new
                        {
                            Id = new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7201),
                            Name = "Bilgisayar",
                            ParentId = new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"),
                            Priorty = 1
                        },
                        new
                        {
                            Id = new Guid("9e611ff4-2260-4ba8-932c-163c2ed4465e"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 12, DateTimeKind.Local).AddTicks(7203),
                            Name = "Kadın",
                            ParentId = new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"),
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Detail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3b18453b-4f06-433b-ac95-7e933016216c"),
                            CategoryId = new Guid("8765ef17-5245-4499-b6bd-bb428a1b0249"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2867),
                            Description = "Adanaya cesurca mıknatıslı bundan.",
                            Title = "Ut."
                        },
                        new
                        {
                            Id = new Guid("d6f5ad11-c86e-4c9d-ba00-9f5c8685f455"),
                            CategoryId = new Guid("6ebed990-84e9-44fa-b36e-f124e14a0118"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2902),
                            Description = "Tv bahar uzattı odit.",
                            Title = "Ab non."
                        },
                        new
                        {
                            Id = new Guid("1ba3f044-6632-486b-978f-7aee1784fa83"),
                            CategoryId = new Guid("2dbc5f92-fa5c-4b2e-b6d2-b22cde7a5e3a"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 14, DateTimeKind.Local).AddTicks(2931),
                            Description = "Quasi ut blanditiis sıradanlıktan.",
                            Title = "Totam."
                        });
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("95ce32b1-ab53-4898-b95b-1e13c8d17f6d"),
                            BrandId = new Guid("6e3e8ed0-1300-4dfa-8855-25724576c837"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 15, DateTimeKind.Local).AddTicks(9705),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Discount = 3.206909398377712m,
                            Price = 601.73m,
                            Title = "Awesome Steel Sausages"
                        },
                        new
                        {
                            Id = new Guid("201e8fc5-4c29-4045-82e1-7cc418311594"),
                            BrandId = new Guid("7e7ed1a0-670f-4b2f-8e55-e79f6f71aca6"),
                            CreateDate = new DateTime(2024, 3, 25, 23, 26, 31, 15, DateTimeKind.Local).AddTicks(9743),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Discount = 6.429604018810496m,
                            Price = 899.08m,
                            Title = "Incredible Metal Tuna"
                        });
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CategoryProduct");
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Detail", b =>
                {
                    b.HasOne("ApiSln.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Product", b =>
                {
                    b.HasOne("ApiSln.Domain.Entities.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CategoryProduct", b =>
                {
                    b.HasOne("ApiSln.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiSln.Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ApiSln.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}