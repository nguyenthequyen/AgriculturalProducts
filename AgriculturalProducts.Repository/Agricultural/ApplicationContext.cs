﻿using AgriculturalProducts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgriculturalProducts.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }

        public DbSet<Category> Categeries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StatusProduct> StatusProducts { get; set; }
        public DbSet<StatusProvider> StatusProviders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<UserInfor> UserInfors { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserAdmin> UserAdmin { get; set; }
        public DbSet<StatusCart> StatusCarts { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
    }
}
