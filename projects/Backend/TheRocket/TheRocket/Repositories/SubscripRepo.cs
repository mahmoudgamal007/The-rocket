using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace T.Repositories
{
    public class SubscripRepo : ISubscripRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper Mapper;

        public SubscripRepo(TheRocketDbContext context, IMapper mapper)
        {
            db = context;
            Mapper = mapper;

        }
        //GetAll
        public async Task<SharedResponse<List<SubscripDto>>> GetAll()
        {
            if (db.Subscrips == null)
            {
                return new SharedResponse<List<SubscripDto>>(Status.notFound, null);
            }
            else
            {
                var subscrips = await db.Subscrips.Include(E => E.Seller)
                    .Include(E => E.Plan).Where(n => n.IsDeleted == false).ToListAsync();
                if (subscrips.Count == 0)
                {
                    return new SharedResponse<List<SubscripDto>>(Status.notFound, null);
                }
                else
                {
                    var subscripsData = Mapper.Map<List<SubscripDto>>(subscrips);

                    return new SharedResponse<List<SubscripDto>>(Status.found, subscripsData);
                }

            }

        }
        //GetById
        public async Task<SharedResponse<SubscripDto>> GetById(int Id)
        {
            if (db.Subscrips == null)
                return new SharedResponse<SubscripDto>(Status.notFound, null);
            var subscrips = await db.Subscrips.Where(s => s.Id == Id && s.IsDeleted == false).FirstOrDefaultAsync();
            var subscripsData = Mapper.Map<SubscripDto>(subscrips);
            return new SharedResponse<SubscripDto>(Status.found, subscripsData);
        }

        //Create
        public async Task<SharedResponse<SubscripDto>> Create(SubscripDto model)
        {
            if (db.Subscrips == null)
            {
                return new SharedResponse<SubscripDto>(Status.problem, null, "Entity Set 'db.Subscrips' is null");
            }

            Subscrip subscrip = Mapper.Map<Subscrip>(model);
            db.Subscrips.Add(subscrip);
            try
            {
                await db.SaveChangesAsync();
             model = Mapper.Map<SubscripDto>(subscrip);

                return new SharedResponse<SubscripDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<SubscripDto>(Status.badRequest, null, ex.ToString());
            }

        }

        //Update
        public async Task<SharedResponse<SubscripDto>> Update(int Id, SubscripDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<SubscripDto>(Status.badRequest, null);
            }

            Subscrip subscrip = Mapper.Map<Subscrip>(model);

            db.Entry(subscrip).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<SubscripDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<SubscripDto>(Status.noContent, null);
        }
        public bool IsExists(int Id)
        {
            return (db.Subscrips?.Any(a => a.Id == Id && a.IsDeleted == false)).GetValueOrDefault();
        }
        //Delete
        public async Task<SharedResponse<SubscripDto>> Delete(int Id)
        {
            if (db.Subscrips == null)
            {
                return new SharedResponse<SubscripDto>(Status.notFound, null);

            }
            var subscrip = await db.Subscrips.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (subscrip == null)
            {
                return new SharedResponse<SubscripDto>(Status.notFound, null);
            }
            subscrip.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<SubscripDto>(Status.noContent, null);
        }

    }
}