using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace T.Repositories
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

        public async Task<List<Feedback>> GetAll()
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

        Task<SharedResponse<List<Product>>> IFeedbackRepo.GetAllProducts()
        {
            throw new NotImplementedException();
        }

        Task<SharedResponse<List<Buyer>>> IFeedbackRepo.GetAllBuyers()
        {
            throw new NotImplementedException();
        }

        Task<List<SharedResponse<FeedbackDto>>> IBaseRepo<SharedResponse<FeedbackDto>, FeedbackDto>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<FeedbackDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<FeedbackDto>> Create(FeedbackDto model)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<FeedbackDto>> Update(int Id, FeedbackDto model)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<FeedbackDto>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int Id)
        {
            throw new NotImplementedException();
        }
        //    public async Task<Feedback> GetById(int ProductId, int BuyerId)
        //    {
        //        return await db.Feedbacks.Where(n => n.IsDeleted == false).SingleOrDefaultAsync(s => s.ProductId == ProductId && s.BuyerId == BuyerId);

        //    }
        //    public async Task<FeedbackDto> AddFeedback(FeedbackDto feedback)
        //    {

        //        //var f = new Feedback();
        //        //Mapper.Map(feedback, f);
        //        //db.Feedbacks.Add(f);
        //        //await db.SaveChangesAsync();
        //        //return f;

        //        Feedback F = Mapper.Map<Feedback>(feedback);
        //        db.Feedbacks.Add(F);

        //            await db.SaveChangesAsync();
        //            feedback = Mapper.Map<FeedbackDto>(F);
        //        return feedback;

        //    }

        //    public async Task<List<Feedback>> UpdateFeedback(int ProductId, int BuyerId, FeedbackDto feedback)
        //    {
        //        Feedback f = Mapper.Map<Feedback>(feedback);

        //        db.Entry(f).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return await db.Feedbacks.ToListAsync();
        //    }
        //}       
    }
}