﻿using WebApiNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiNetCore.Models
{
    public class EFDataContext : DbContext

    {
        public EFDataContext(DbContextOptions<EFDataContext> options)
           : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //config primary key(product,category)
            modelBuilder.Entity<Product>().HasKey(s => s.idProduct);
            modelBuilder.Entity<Category>().HasKey(s => s.idCategory);
            modelBuilder.Entity<User>().HasKey(s => s.idUser);

            //set config replationship Product vs Category
            modelBuilder.Entity<Category>()
                .HasMany<Product>(s => s.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.idCategory)
                .OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
