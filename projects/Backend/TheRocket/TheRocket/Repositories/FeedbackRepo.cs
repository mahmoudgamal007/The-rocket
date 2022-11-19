using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;
using TheRocket.Repositories;
using AutoMapper;
using TheRocket.Dtos;
using TheRocket.Dtos.UserDtos;
using TheRocket.Shared;
using System.Numerics;

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

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await db.Feedbacks.Include(E => E.Product).Include(E => E.Buyer).Where(n => n.IsDeleted == false).ToListAsync();
        }


        public async Task<List<Product>> GetAllProducts()
        {
            return await db.Products.Where(n => n.IsDeleted == false).ToListAsync();
        }
        public async Task<List<Buyer>> GetAllBuyers()
        {
            return await db.Buyers.ToListAsync();
        }
        public async Task<Feedback> GetById(int ProductId, int BuyerId)
        {
            return await db.Feedbacks.Where(n => n.IsDeleted == false).SingleOrDefaultAsync(s => s.ProductId == ProductId && s.BuyerId == BuyerId);

        }
        public async Task<FeedbackDto> AddFeedback(FeedbackDto feedback)
        {

            //var f = new Feedback();
            //Mapper.Map(feedback, f);
            //db.Feedbacks.Add(f);
            //await db.SaveChangesAsync();
            //return f;
   
            Feedback F = Mapper.Map<Feedback>(feedback);
            db.Feedbacks.Add(F);
           
                await db.SaveChangesAsync();
                feedback = Mapper.Map<FeedbackDto>(F);
            return feedback;

        }

        public async Task<List<Feedback>> UpdateFeedback(int ProductId, int BuyerId, FeedbackDto feedback)
        {
            Feedback f = Mapper.Map<Feedback>(feedback);

            db.Entry(f).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return await db.Feedbacks.ToListAsync();
        }
    }       
}