using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Extensions.Options;
using Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Data;
using AutoMapper.Configuration;

namespace Data
{
    public class ParsMarketDbContext : IdentityDbContext
    {
        public ParsMarketDbContext(
            DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }



        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OffCodes> OffCodes { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<DayWeek> DayWeeks { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<ProductGallery> productGalleries { get; set; }

        public DbSet<ProductVisit> productVisits { get; set; }
        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Product>().Property(p => p.Image).HasColumnType("image");
            //       modelBuilder.Entity<Menu>()
            //.HasOne(m=>m.Parent)
            //.WithMany()
            //.OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<CategoryToProduct>().HasKey(c=>new { 
            //c.CategoryId,c.ProductId
            //});

            //modelBuilder.Entity<Product>().HasData(new Product()
            //{
            //    Id = new Guid("4166bf83-1ded-4469-93f9-2aa551c01f97"),
            //    Name = "software",
            //    ShortDescription = "software ",
            //    CartItemId = new Guid("17fd4c26-d268-4155-82e2-c50bf54c4a72"),
            //});

            //modelBuilder.Entity<CartItem>().HasData(new CartItem()
            //{
            //    Id = new Guid("17fd4c26-d268-4155-82e2-c50bf54c4a72"),
            //    QuantityInStock = 2,
            //    Price = 12000
            //});

            //modelBuilder.Entity<Person>().HasData(new Person()
            //{
            //    Id = new Guid("2aecab67-2bab-4b00-aff6-fbb459f58cc4"),
            //    Email = "Askar@gmail.com",
            //    IsAdmin = true,
            //    FirstName = "askar",
            //    Password = "1234",
            //    InsertDateTime = DateTime.UtcNow
            //});

            modelBuilder.Entity<Menu>()
                   .HasOne(m => m.Parent)
                      .WithMany(m => m.SubMenus)
                           ;

            // modelBuilder.Entity<Cart>().HasOne(c => c.Products).WithMany().OnDelete(DeleteBehavior.SetNull);


        }

    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<Data.ParsMarketDbContext>
{

    public ParsMarketDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ParsMarketDbContext>();
        optionsBuilder.UseSqlServer("Server=.; Database=DbPars; User Id=sa ; Password=1234512345; Trusted_Connection=True;");

        return new ParsMarketDbContext(optionsBuilder.Options);
    }
}


