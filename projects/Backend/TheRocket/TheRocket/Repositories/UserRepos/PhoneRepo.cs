using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.UserDtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.Entities;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities.Users;

namespace TheRocket.Repositories
{
     public class PhoneRepo : IPhoneRepo
    {

        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;

        public PhoneRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<SharedResponse<PhoneDto>> Create(PhoneDto model)
        {


            if (db.Phones == null)
            {
                return new SharedResponse<PhoneDto>(Status.problem, null, "Entity Set 'db.Phone' is null");
            }
            
            Phone Phone = mapper.Map<Phone>(model);
            db.Phones.Add(Phone);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<PhoneDto>(Phone);
                return new SharedResponse<PhoneDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<PhoneDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<PhoneDto>> Delete(int Id)
        {
            if (db.Phones == null)
            {
                return new SharedResponse<PhoneDto>(Status.notFound, null);

            }
            var Phone = await db.Phones.Where(p =>p.Id == Id && p.IsDeleted == false).FirstOrDefaultAsync();
            if (Phone == null)
            {
                return new SharedResponse<PhoneDto>(Status.notFound, null);
            }
            Phone.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<PhoneDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<PhoneDto>>> GetPhonesByUserId(string AppUserId)
        {
            if (db.Phones == null)
                return new SharedResponse<List<PhoneDto>>(Status.notFound, null);
            var PhonesDto = await db.Phones.Where(p =>p.AppUserId == AppUserId && p.IsDeleted == false).ToListAsync();
            List<PhoneDto> Phones = mapper.
            Map<List<PhoneDto>>(PhonesDto);
            return new SharedResponse<List<PhoneDto>>(Status.found, Phones);
        }

      

        public async Task<SharedResponse<PhoneDto>> GetById(int Id)
        {
            if (db.Phones == null)
                return new SharedResponse<PhoneDto>(Status.notFound, null);
            var PhoneDto = await db.Phones.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            PhoneDto Phone = mapper.
            Map<PhoneDto>(PhoneDto);
            return new SharedResponse<PhoneDto>(Status.found, Phone);

        }

        public async Task<SharedResponse<PhoneDto>> Update(int Id, PhoneDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<PhoneDto>(Status.badRequest, null);
            }

            Phone Phone = mapper.Map<Phone>(model);

            db.Entry(Phone).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<PhoneDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<PhoneDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.Phones?.Any(p => p.Id == Id&&p.IsDeleted==false)).GetValueOrDefault();
        }

       public async Task<SharedResponse<List<PhoneDto>>> GetAll()
        {
            
            if (db.Phones == null)
                return new SharedResponse<List<PhoneDto>>(Status.notFound, null);
            var PhonesDto = await db.Phones.Where(a => a.IsDeleted == false).ToListAsync();
            List<PhoneDto> Phones = mapper.
            Map<List<PhoneDto>>(PhonesDto);
            return new SharedResponse<List<PhoneDto>>(Status.found, Phones);
        }
    }
}