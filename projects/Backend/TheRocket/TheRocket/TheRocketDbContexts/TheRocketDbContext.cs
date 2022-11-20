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
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin" ,NormalizedName="ADMIN"});

        }



        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductColor> Colors { get; set; }
        public virtual DbSet<ProductSize> Sizes { get; set; }
        public virtual DbSet<ImgUrl> ImgUrls { get; set; }
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

