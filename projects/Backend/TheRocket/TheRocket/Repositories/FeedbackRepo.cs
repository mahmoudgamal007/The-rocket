using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
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
        //GetAll
        public async Task<SharedResponse<List<FeedbackDto>>> GetAllFeedbacks()
        {
            if (db.Feedbacks == null)
            {
                return new SharedResponse<List<FeedbackDto>>(Status.notFound, null);
            }
            else
            {
                var feedbacks = await db.Feedbacks.Include(E => E.Product)
                    .Include(E => E.Buyer).Where(n => n.IsDeleted == false).ToListAsync();
                if (feedbacks.Count == 0)
                {
                    return new SharedResponse<List<FeedbackDto>>(Status.notFound, null);
                }
                else
                {
                    var feedbacksData = Mapper.Map<List<FeedbackDto>>(feedbacks);

                    return new SharedResponse<List<FeedbackDto>>(Status.found, feedbacksData);
                }

            }

        }
        //GetById
        public async Task<SharedResponse<List<FeedbackDto>>> GetFeedbackbyId(int ProductId, int BuyerId)
        {
            if (db.Feedbacks == null)
                return new SharedResponse<List<FeedbackDto>>(Status.notFound, null);
            var feedbacks = await db.Feedbacks.Where(s => s.ProductId == ProductId && s.BuyerId == BuyerId && s.IsDeleted == false).ToListAsync();
            var feedbacksData = Mapper.Map< List<FeedbackDto>>(feedbacks);
            return new SharedResponse<List<FeedbackDto>>(Status.found, feedbacksData);
        }

        //Create
        public async Task<SharedResponse<FeedbackDto>> Create(FeedbackDto model)
        {
            if (db.Feedbacks == null)
            {
                return new SharedResponse<FeedbackDto>(Status.problem, null, "Entity Set 'db.Feedbacks' is null");
            }

            Feedback feedback = Mapper.Map<Feedback>(model);
            db.Feedbacks.Add(feedback);
            try
            {
                await db.SaveChangesAsync();
             model = Mapper.Map<FeedbackDto>(feedback);

                return new SharedResponse<FeedbackDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<FeedbackDto>(Status.badRequest, null, ex.ToString());
            }

        }
        //Update
        public async Task<SharedResponse<FeedbackDto>> UpdateFeedback(int ProductId, int BuyerId, FeedbackDto model)
        {
            if (ProductId != model.ProductId && BuyerId!=model.BuyerId)
            {
                return new SharedResponse<FeedbackDto>(Status.badRequest, null);
            }

            Feedback feedback = Mapper.Map<Feedback>(model);

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                if (IsExist(ProductId,BuyerId))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<FeedbackDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<FeedbackDto>(Status.noContent, null);
        }
        public bool IsExist(int ProductId, int BuyerId)
        {
            return (db.Feedbacks?.Any(a => a.ProductId == ProductId && a.BuyerId == BuyerId && a.IsDeleted == false)).GetValueOrDefault();
        }
        //Delete
        public async Task<SharedResponse<FeedbackDto>> DeleteFeedback(int ProductId,int BuyerId)
        {
            if (db.Feedbacks == null)
            {
                return new SharedResponse<FeedbackDto>(Status.notFound, null);

            }
            var feedback = await db.Feedbacks.Where(a => a.ProductId == ProductId && a.BuyerId == BuyerId && a.IsDeleted == false).FirstOrDefaultAsync();
            if (feedback == null)
            {
                return new SharedResponse<FeedbackDto>(Status.notFound, null);
            }
            feedback.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<FeedbackDto>(Status.noContent, null);
        }

        public Task<SharedResponse<FeedbackDto>> GetById(int Id)
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

        Task<SharedResponse<List<FeedbackDto>>> IBaseRepo<SharedResponse<FeedbackDto>, SharedResponse<List<FeedbackDto>>, FeedbackDto>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}