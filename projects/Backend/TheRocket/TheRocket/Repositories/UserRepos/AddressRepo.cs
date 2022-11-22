using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class AddressRepo : IAddressRepo
    {

        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;

        public AddressRepo(TheRocketDbContext db, IMapper mapper)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<SharedResponse<AddressDto>> Create(AddressDto model)
        {


            if (db.Addresses == null)
            {
                return new SharedResponse<AddressDto>(Status.problem, null, "Entity Set 'db.Address' is null");
            }
            Address address = mapper.Map<Address>(model);
            db.Addresses.Add(address);
            try
            {
                await db.SaveChangesAsync();
                model = mapper.Map<AddressDto>(address);
                return new SharedResponse<AddressDto>(Status.createdAtAction, model);
            }
            catch (Exception ex)
            {
                return new SharedResponse<AddressDto>(Status.badRequest, null, ex.ToString());
            }

        }

        public async Task<SharedResponse<AddressDto>> Delete(int Id)
        {
            if (db.Addresses == null)
            {
                return new SharedResponse<AddressDto>(Status.notFound, null);

            }
            var address = await db.Addresses.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            if (address == null)
            {
                return new SharedResponse<AddressDto>(Status.notFound, null);
            }
            address.IsDeleted = true;
            await db.SaveChangesAsync();
            return new SharedResponse<AddressDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<AddressDto>>> GetAddressesByUserId(string AppUserId)
        {
            if (db.Addresses == null)
                return new SharedResponse<List<AddressDto>>(Status.notFound, null);
            var addressesDto = await db.Addresses.Where(a => a.AppUserId == AppUserId && a.IsDeleted == false).ToListAsync();
            List<AddressDto> addresses = mapper.
            Map<List<AddressDto>>(addressesDto);
            return new SharedResponse<List<AddressDto>>(Status.found, addresses);
        }



        public async Task<SharedResponse<AddressDto>> GetById(int Id)
        {
            if (db.Addresses == null)
                return new SharedResponse<AddressDto>(Status.notFound, null);
            var addressDto = await db.Addresses.Where(a => a.Id == Id && a.IsDeleted == false).FirstOrDefaultAsync();
            AddressDto address = mapper.
            Map<AddressDto>(addressDto);
            return new SharedResponse<AddressDto>(Status.found, address);
        }

        public async Task<SharedResponse<AddressDto>> Update(int Id, AddressDto model)
        {
            if (Id != model.Id)
            {
                return new SharedResponse<AddressDto>(Status.badRequest, null);
            }

            Address address = mapper.Map<Address>(model);

            db.Entry(address).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<AddressDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<AddressDto>(Status.noContent, null);
        }

        public bool IsExists(int Id)
        {
            return (db.Addresses?.Any(a => a.Id == Id && a.IsDeleted == false)).GetValueOrDefault();
        }

        public async Task<SharedResponse<List<AddressDto>>> GetAll()
        {
            if (db.Addresses == null)
                return new SharedResponse<List<AddressDto>>(Status.notFound, null);
            var addressesDto = await db.Addresses.Where(a => a.IsDeleted == false).ToListAsync();
            List<AddressDto> addresses = mapper.
            Map<List<AddressDto>>(addressesDto);
            return new SharedResponse<List<AddressDto>>(Status.found, addresses);
        }


    }
}