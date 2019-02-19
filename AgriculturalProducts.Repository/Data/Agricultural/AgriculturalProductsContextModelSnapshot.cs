﻿// <auto-generated />
using System;
using AgriculturalProducts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgriculturalProducts.Repository.Data.Agricultural
{
    [DbContext(typeof(AgriculturalProductsContext))]
    partial class AgriculturalProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AgriculturalProducts.Models.Categery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categeries");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategeryId");

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Code");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("FullDescription")
                        .IsRequired();

                    b.Property<decimal>("Mass");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid>("ProviderId");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("SaleId");

                    b.Property<string>("ShortDescription")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<Guid?>("TypeId");

                    b.Property<Guid>("TypeTypeId");

                    b.Property<Guid>("UnitId");

                    b.Property<int>("View");

                    b.HasKey("Id");

                    b.HasIndex("CategeryId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("SaleId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Provider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("Id");

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

            modelBuilder.Entity("AgriculturalProducts.Models.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Expires");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("RemoteIpAddress");

                    b.Property<string>("Token");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Roles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsSale");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<int>("Percent");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IdentityId");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifyDate");

                    b.Property<string>("PasswordHash");

                    b.Property<Guid>("RolesId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Image", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AgriculturalProducts.Models.Product", b =>
                {
                    b.HasOne("AgriculturalProducts.Models.Categery", "Categery")
                        .WithMany()
                        .HasForeignKey("CategeryId");

                    b.HasOne("AgriculturalProducts.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AgriculturalProducts.Models.ProductType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.HasOne("AgriculturalProducts.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
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

            modelBuilder.Entity("AgriculturalProducts.Models.RefreshToken", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
