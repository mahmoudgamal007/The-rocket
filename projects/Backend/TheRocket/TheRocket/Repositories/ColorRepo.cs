using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ColourRepo : IColorRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        public ColourRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;

        }
        public async Task<SharedResponse<ColorDto>> Create(ColorDto model)
        {

            if (db.Colors == null)
            {
                return new SharedResponse<ColorDto>(Status.problem, null, "Entity Set 'db.Colour' is null");
            }
            Colour Colour = mapper.Map<Colour>(model);
            Colour.Name = Colour.Name.ToLower();
            var color =await db.Colors.Where(c => c.Name == model.Name && c.IsDeleted == false).FirstOrDefaultAsync();
            if (color != null)
            {
                var colorDto = mapper.Map<ColorDto>(color);
                return new SharedResponse<ColorDto>(Status.found, colorDto,"this color is already exist");
            }
            db.Colors.Add(Colour);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<ColorDto>(Colour);
                return new SharedResponse<ColorDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<ColorDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<ColorDto>> Delete(int Id)
        {
            if (db.Colors == null)
            {
                return new SharedResponse<ColorDto>(Status.notFound, null);

            }
            var Colour = await db.Colors.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefaultAsync();
            if (Colour == null)
            {
                return new SharedResponse<ColorDto>(Status.notFound, null);
            }
            Colour.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<ColorDto>(Status.noContent, null);
        }


        public async Task<SharedResponse<ColorDto>> GetById(int Id)
        {
            if (db.Colors == null)
            {
                return new SharedResponse<ColorDto>(Status.notFound, null);
            }
            var color = await db.Colors.Where(c => c.Id == Id && c.IsDeleted == false).FirstOrDefaultAsync();
            if (color == null)
                return new SharedResponse<ColorDto>(Status.notFound, null);
            var colorDto = mapper.Map<ColorDto>(color);
            return new SharedResponse<ColorDto>(Status.found, colorDto);
        }

        public async Task<SharedResponse<ColorDto>> Update(int Id, ColorDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<ColorDto>(Status.badRequest, null);
            }

            Colour Colour = mapper.Map<Colour>(model);

            db.Entry(Colour).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<ColorDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<ColorDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.Colors?.Any(c => c.Id == Id && c.IsDeleted == false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<List<ColorDto>>> GetAll()
        {
            if (db.Colors == null)
            {
                return new SharedResponse<List<ColorDto>>(Status.notFound, null);
            }
            var colors = mapper.Map<List<ColorDto>>(await db.Colors.Where(c => c.IsDeleted == false).ToListAsync());
            return new SharedResponse<List<ColorDto>>(Status.found, colors);
        }


    }
}