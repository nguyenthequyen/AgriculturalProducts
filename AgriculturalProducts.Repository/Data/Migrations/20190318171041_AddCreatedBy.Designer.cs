﻿// <auto-generated />
using System;
using AgriculturalProducts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgriculturalProducts.Repository.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190318171041_AddCreatedBy")]
    partial class AddCreatedBy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgriculturalProducts.Models.Blogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categeries");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Path")
                        .IsRequired();

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<Guid>("StatusCartsId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StatusCartsId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.OrderDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<Guid>("OrderId");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<float>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<decimal>("Cost");

                    b.Property<decimal>("CostOld");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FullDescription")
                        .IsRequired();

                    b.Property<decimal>("Mass");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("ProductTypeId");

                    b.Property<Guid>("ProviderId");

                    b.Property<int>("Quantity");

                    b.Property<int>("Sale");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<Guid>("StatusProductId");

                    b.Property<Guid>("UnitId");

                    b.Property<int>("View");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("StatusProductId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DateTimeRegister");

                    b.Property<DateTime>("DateTimeStop");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<Guid>("StatusProviderId");

                    b.HasKey("Id");

                    b.HasIndex("StatusProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Rate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<Guid>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Statistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Action");

                    b.Property<string>("ActionName");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.HasKey("Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.StatusCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("StatusCarts");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.StatusProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StatusProducts");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.StatusProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StatusProviders");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<Guid>("RolesId");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.UserAdmin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Password");

                    b.Property<Guid>("RolesId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("UserAdmin");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.UserInfor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserInfors");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Comments", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Image", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Order", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.StatusCart", "StatusCarts")
                        .WithMany()
                        .HasForeignKey("StatusCartsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.OrderDetails", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Product", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.ProductType", "Type")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.StatusProduct", "StatusProduct")
                        .WithMany()
                        .HasForeignKey("StatusProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Provider", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.StatusProvider", "StatusProvider")
                        .WithMany()
                        .HasForeignKey("StatusProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Rate", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.User", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.UserAdmin", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.UserInfor", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
