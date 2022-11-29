using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Entities;
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
        public async Task<SharedResponse<List<FeedbackDto>>> GetAll()
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
        public async Task<SharedResponse<FeedbackDto>> GetById(int Id)
        {
            if (db.Feedbacks == null)
                return new SharedResponse<FeedbackDto>(Status.notFound, null);
            var feedbacks = await db.Feedbacks.Where(s => s.Id == Id && s.IsDeleted == false).FirstOrDefaultAsync();
            FeedbackDto feedbacksData = Mapper.Map<FeedbackDto>(feedbacks);
            return new SharedResponse<FeedbackDto>(Status.found, feedbacksData);
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
        public async Task<SharedResponse<FeedbackDto>> Update(int Id, FeedbackDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<FeedbackDto>(Status.badRequest, null);
            }

            Feedback feedback = Mapper.Map<Feedback>(model);

            db.Entry(feedback).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
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
        public bool IsExists(int Id)
        {
            return (db.Feedbacks?.Any(a => a.Id == Id && a.IsDeleted == false)).GetValueOrDefault();
        }
        //Delete
        public async Task<SharedResponse<FeedbackDto>> Delete(int Id)
        {
            if (db.Feedbacks == null)
            {
                return new SharedResponse<FeedbackDto>(Status.notFound, null);

            }
            var feedback = await db.Feedbacks.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (feedback == null)
            {
                return new SharedResponse<FeedbackDto>(Status.notFound, null);
            }
            feedback.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<FeedbackDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<FeedbackDto>>> GetAllFeedbacsByProductId(int prodcutID)
        {
            if (db.Feedbacks == null)
            {
                return new SharedResponse<List<FeedbackDto>>(Status.notFound, null);
            }
            else
            {
                var feedbacks = await db.Feedbacks.Include(E => E.Product)
                    .Include(E => E.Buyer).Where(n => n.IsDeleted == false&&n.ProductId==prodcutID).ToListAsync();
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
    }
}