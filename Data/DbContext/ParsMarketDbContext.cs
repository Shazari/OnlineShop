using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ParsMarketDbContext : DbContext
    {
        public ParsMarketDbContext(DbContextOptions<ParsMarketDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
       // public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }
       // public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
       // public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<OffCodes> OffCodes { get; set; }
        //public DbSet<CodeProduct> CodeProducts { get; set; }
        public DbSet<Contact>   Contacts { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<DayWeek> DayWeeks { get; set; }
        



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
