using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class ReserveCartRepo : IReserveCart
    {

        private readonly TheRocketDbContext db;
        private readonly IMapper _mapper;

        public ReserveCartRepo(TheRocketDbContext db, IMapper mapper)
        {
            this._mapper = mapper;
            this.db = db;
        }
        public async Task<SharedResponse<ReserveCartDto>> Create(ReserveCartDto model)
        {
            if (db.ReserveCarts == null)
            {
                return new SharedResponse<ReserveCartDto>(Status.problem, null, "Entity Set 'db.ReserveCarts' is null");
            }
            ReserveCart reserveCart = _mapper.Map<ReserveCart>(model);
            db.ReserveCarts.Add(reserveCart);
            try
            {
                await db.SaveChangesAsync();
                model = _mapper.Map<ReserveCartDto>(reserveCart);
                return new SharedResponse<ReserveCartDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<ReserveCartDto>(Status.badRequest, null, ex.ToString());
            }
        }

        public async Task<SharedResponse<ReserveCartDto>> Delete(int Id)
        {
            if (db.ReserveCarts == null)
            {
                return new SharedResponse<ReserveCartDto>(Status.notFound, null);

            }
            var reserveCart = await db.ReserveCarts.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (reserveCart == null)
            {
                return new SharedResponse<ReserveCartDto>(Status.notFound, null);
            }
            reserveCart.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<ReserveCartDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<ReserveCartDto>>> GetAll()
        {
            if (db.ReserveCarts == null)
            {
                return new SharedResponse<List<ReserveCartDto>>(Status.notFound, null);
            }

            var reserveCartDto = await db.ReserveCarts.Where(s => s.IsDeleted == false).ToListAsync();
            List<ReserveCartDto> reserveCarts = _mapper.Map<List<ReserveCartDto>>(reserveCartDto);
            return new SharedResponse<List<ReserveCartDto>>(Status.found, reserveCarts);

        }

        public async Task<SharedResponse<ReserveCartDto>> GetById(int Id)
        {
            if (db.ReserveCarts == null)
            {
                return new SharedResponse<ReserveCartDto>(Status.notFound, null, "db.ReserveCartDto is null");
            }
            var reserveCart = await db.ReserveCarts.SingleOrDefaultAsync(s => s.Id == Id && s.IsDeleted == false);
            if (reserveCart == null)
            {
                return new SharedResponse<ReserveCartDto>(Status.notFound, null);
            }
            var model = _mapper.Map<ReserveCartDto>(reserveCart);

            return new SharedResponse<ReserveCartDto>(Status.found, model);
        }

        public bool IsExists(int Id)
        {
            return (db.ReserveCarts?.Any(a => a.Id == Id && a.IsDeleted == false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<ReserveCartDto>> Update(int Id, ReserveCartDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<ReserveCartDto>(Status.badRequest, null);
            }

            ReserveCart reserveCart = _mapper.Map<ReserveCart>(model);

            db.Entry(reserveCart).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<ReserveCartDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<ReserveCartDto>(Status.noContent, null);
        }
    }
}
