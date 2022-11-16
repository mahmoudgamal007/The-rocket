using System;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.TheRocketDbContexts
{
	public class TheRocketDbContext:IdentityDbContext<AppUser>
	{
		public TheRocketDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

            builder.Entity<Feedback>().HasKey(f => new { f.BuyerId, f.ProductId });
            builder.Entity<ReserveCart>().HasKey(r => new { r.BuyerId, r.ProductId });
            builder.Entity<Subscrip>().HasKey(s => new { s.SellerId, s.PlanId });
           
        }

        public virtual  DbSet<Product> Products { get; set; }
        public virtual  DbSet<ProductColor> Colors { get; set; }
        public virtual  DbSet<ProductSize> Sizes { get; set; }
        public virtual  DbSet<ImgUrl> ImgUrls { get; set; }
        public virtual  DbSet<Address> Addresses { get; set; }
        public virtual  DbSet<Buyer> Buyers { get; set; }
        public virtual  DbSet<Locations> Locations { get; set; }
        public virtual  DbSet<Phone> Phones { get; set; }
        public virtual  DbSet<Seller> Sellers { get; set; }
        public virtual  DbSet<Feedback> Feedbacks { get; set; }
        public virtual  DbSet<Order> Orders { get; set; }
        public virtual  DbSet<Plan> Plans { get; set; }
        public virtual  DbSet<ReserveCart> ReserveCarts { get; set; }
        public virtual  DbSet<SubCategory> SubCategories { get; set; }
        public virtual  DbSet<Subscrip> Subscrips { get; set; }

    }
}

