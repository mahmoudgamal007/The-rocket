using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;
using TheRocket.Repositories;
using AutoMapper;

namespace DependancyInjection.Repositories
{
    public class FeedbackRepo : IFeedbackRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper Mapper;

        public FeedbackRepo(TheRocketDbContext context, IMapper mapper)
        {
            db = context;
            Mapper = mapper;

        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            return db.Feedbacks.Include(E => E.Product).Include(E => E.Buyer).Where(n => n.IsDeleted == false).ToList();
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.Where(n => n.IsDeleted == false).ToList();
        }
        public IEnumerable<Buyer> GetAllBuyers()
        {
            return db.Buyers.ToList();
        }
        public async Task<Feedback> GetById(int ProductId, int BuyerId)
        {
            return await db.Feedbacks.Where(n => n.IsDeleted == false).SingleOrDefaultAsync(s => s.ProductId == ProductId && s.BuyerId == BuyerId);

        }
    }
}