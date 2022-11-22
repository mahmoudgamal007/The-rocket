using System;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.TheRocketDbContexts
{
    public class TheRocketDbContext : IdentityDbContext<AppUser>
    {
        public TheRocketDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductColor>().HasKey(p => new { p.ProductId, p.ColourId });
            builder.Entity<ProductSize>().HasKey(p => new { p.ProductId, p.SizeId });

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "Seller", NormalizedName = "SELLER" },
                new IdentityRole { Name = "Buyer", NormalizedName = "BUYER" }
             );

             builder.Entity<Colour>().HasData(
                new Colour{Id=1,Name="White"},
                new Colour{Id=2,Name="Red"},
                new Colour{Id=3,Name="Blue"},
                new Colour{Id=4,Name="Yellow"},
                new Colour{Id=5,Name="Black"}
             );

             builder.Entity<Size>().HasData(
                new Size{Id=1,Name="S"},
                new Size{Id=2,Name="M"},
                new Size{Id=3,Name="L"},
                new Size{Id=4,Name="XL"}
             );

        }



        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Colour> Colors { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductImgUrl> ProductImgUrls { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<ReserveCart> ReserveCarts { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Subscrip> Subscrips { get; set; }

    }
}

