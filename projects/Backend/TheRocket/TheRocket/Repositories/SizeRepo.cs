using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class SizeRepo : ISizeRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        public SizeRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;

        }
        public async Task<SharedResponse<SizeDto>> Create(SizeDto model)
        {

            if (db.Sizes == null)
            {
                return new SharedResponse<SizeDto>(Status.problem, null, "Entity Set 'db.Size' is null");
            }
            Size Size = mapper.Map<Size>(model);
            Size.Name = Size.Name.ToLower();
            var sizeDto =await db.Sizes.Where(c => c.Name == model.Name && c.IsDeleted == false).FirstOrDefaultAsync();
            if (sizeDto != null)
            {
                var SizeDto = mapper.Map<SizeDto>(sizeDto);
                return new SharedResponse<SizeDto>(Status.found, SizeDto,"this Size is already exist");
            }
            db.Sizes.Add(Size);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<SizeDto>(Size);
                return new SharedResponse<SizeDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<SizeDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<SizeDto>> Delete(int Id)
        {
            if (db.Sizes == null)
            {
                return new SharedResponse<SizeDto>(Status.notFound, null);

            }
            var Size = await db.Sizes.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefaultAsync();
            if (Size == null)
            {
                return new SharedResponse<SizeDto>(Status.notFound, null);
            }
            Size.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<SizeDto>(Status.noContent, null);
        }


        public async Task<SharedResponse<SizeDto>> GetById(int Id)
        {
            if (db.Sizes == null)
            {
                return new SharedResponse<SizeDto>(Status.notFound, null);
            }
            var Size = await db.Sizes.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefaultAsync();
            if (Size == null)
                return new SharedResponse<SizeDto>(Status.notFound, null);
            var SizeDto = mapper.Map<SizeDto>(Size);
            return new SharedResponse<SizeDto>(Status.found, SizeDto);
        }

        public async Task<SharedResponse<SizeDto>> Update(int Id, SizeDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<SizeDto>(Status.badRequest, null);
            }

            Size Size = mapper.Map<Size>(model);

            db.Entry(Size).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<SizeDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<SizeDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.Sizes?.Any(c => c.Id == Id && c.IsDeleted == false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<List<SizeDto>>> GetAll()
        {
            if (db.Sizes == null)
            {
                return new SharedResponse<List<SizeDto>>(Status.notFound, null);
            }
            var Sizes = mapper.Map<List<SizeDto>>(await db.Sizes.Where(c => c.IsDeleted == false).ToListAsync());
            return new SharedResponse<List<SizeDto>>(Status.found, Sizes);
        }


    }
}