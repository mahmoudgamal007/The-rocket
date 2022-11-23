using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories
{
    public class BuyerRepo : IBuyerRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IAddressRepo addressRepo;
        private readonly IPhoneRepo phoneRepo;
        private readonly ILocationRepo locationRepo;
        private readonly RoleManager<IdentityRole> roleManager;

        public BuyerRepo(TheRocketDbContext db, IMapper mapper, UserManager<AppUser> userManager,
         IAddressRepo addressRepo, IPhoneRepo phoneRepo, ILocationRepo locationRepo, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.locationRepo = locationRepo;
            this.phoneRepo = phoneRepo;
            this.userManager = userManager;
            this.addressRepo = addressRepo;
            this.mapper = mapper;
            this.db = db;

        }
        public async Task<SharedResponse<BuyerDto>> Create(BuyerDto model)
        {
            if (db.Buyers == null) return new SharedResponse<BuyerDto>(Status.problem, null, "Entity set 'db.Buyer' is null");
            SharedResponse<AddressDto> addressResponse;
            SharedResponse<PhoneDto> phoneResponse;
            SharedResponse<LocationDto> locationResponse;
            SharedResponse<IdentityResult> identityResponse;
            IdentityResult identityResult;
            string message = "";


            AppUser appUser = mapper.Map<AppUser>(model);
            Buyer buyer = mapper.Map<Buyer>(model);

            if (appUser != null && buyer != null)
            {
                identityResult = await userManager.CreateAsync(appUser, model.Password);
                if (identityResult.Succeeded)
                {
                    model = mapper.Map<BuyerDto>(appUser);
                    buyer.AppUserId = appUser.Id;
                    db.Buyers.Add(buyer);
                    if (model.Addresse != null)
                    {
                        model.Addresse.AppUserId = appUser.Id;
                        addressResponse = await addressRepo.Create(model.Addresse);
                        model.Addresse = addressResponse.data;
                        message += addressResponse.message + ", ";
                    }
                    if (model.PhoneNumber != null)
                    {
                        model.PhoneNumber.AppUserId = appUser.Id;
                        phoneResponse = await phoneRepo.Create(model.PhoneNumber);
                        model.PhoneNumber = phoneResponse.data;
                        message += phoneResponse.message + ", ";
                    }
                    if (model.Location != null)
                    {
                        model.Location.AppUserId = appUser.Id;
                        locationResponse = await locationRepo.Create(model.Location);
                        model.Location = locationResponse.data;
                        message += locationResponse.message + ", ";
                    }
                    try
                    {

                        var roles = await roleManager.FindByNameAsync("Buyer");
                        if (roles != null)
                        {
                            await db.SaveChangesAsync();
                            model = mapper.Map<BuyerDto>(buyer);
                            model.UserName = appUser.UserName;
                            model.Email = appUser.Email;
                            identityResult = await userManager.AddToRoleAsync(appUser, "Buyer");
                        }
                        else
                        {
                            db.Buyers.Remove(buyer);
                            throw new Exception("Buyer Role not Found");
                        }
                        return new SharedResponse<BuyerDto>(Status.createdAtAction, model, message);
                    }
                    catch (Exception ex)
                    {
                        if (buyer != null)
                            await Delete(buyer.BuyerId);

                        if (model.Addresse != null)
                            await addressRepo.Delete(model.Addresse.Id);

                        if (model.PhoneNumber != null)
                            await phoneRepo.Delete(model.PhoneNumber.Id);

                        if (model.Location != null)
                            await locationRepo.Delete(model.Location.Id);
                        await userManager.DeleteAsync(appUser);
                        return new SharedResponse<BuyerDto>(Status.badRequest, null, ex.ToString());
                    }

                }
                string identityReponse = JsonConvert.SerializeObject(identityResult);

                return new SharedResponse<BuyerDto>(Status.badRequest, null, identityReponse);
            }
            return new SharedResponse<BuyerDto>(Status.badRequest, null);

        }

        public async Task<SharedResponse<BuyerDto>> Delete(int Id)
        {
            if (db.Buyers == null)
            {
                return new SharedResponse<BuyerDto>(Status.notFound, null);

            }
            var admin = await db.Buyers.Where(a => a.BuyerId == Id).FirstOrDefaultAsync();
            if (admin == null)
            {
                return new SharedResponse<BuyerDto>(Status.notFound, null);
            }
            db.Buyers.Remove(admin);
            await db.SaveChangesAsync();
            return new SharedResponse<BuyerDto>(Status.noContent, null);
        }



        public async Task<SharedResponse<BuyerDto>> GetById(int Id)
        {

            if (db.Buyers == null)
                return new SharedResponse<BuyerDto>(Status.notFound, null);
            var Admin = await db.Buyers.Where(a => a.BuyerId == Id).FirstOrDefaultAsync();
            BuyerDto BuyerDto = mapper.
            Map<BuyerDto>(Admin);
            return new SharedResponse<BuyerDto>(Status.found, BuyerDto);

        }

        public async Task<SharedResponse<BuyerDto>> GetByUserId(string AppUserId)
        {
            if (db.Buyers == null)
                return new SharedResponse<BuyerDto>(Status.notFound, null);
            var Buyers = await db.Buyers.Where(a => a.AppUserId == AppUserId).FirstOrDefaultAsync();
            BuyerDto BuyerDto = mapper.
            Map<BuyerDto>(Buyers);
            return new SharedResponse<BuyerDto>(Status.found, BuyerDto);
        }

        public bool IsExists(int Id)
        {
            return (db.Buyers?.Any(a => a.BuyerId == Id)).GetValueOrDefault();
        }

        public async Task<SharedResponse<BuyerDto>> Update(int Id, BuyerDto model)
        {
            if (Id != model.BuyerId)
            {
                return new SharedResponse<BuyerDto>(Status.badRequest, null);
            }

            Admin admin = mapper.Map<Admin>(model);

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<BuyerDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<BuyerDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<BuyerDto>>> GetAll()
        {
            if (db.Buyers == null)
                return new SharedResponse<List<BuyerDto>>(Status.notFound, null);
            var Buyers = await db.Buyers.ToListAsync();
            List<BuyerDto> BuyerDtos = mapper.
            Map<List<BuyerDto>>(Buyers);
            return new SharedResponse<List<BuyerDto>>(Status.found, BuyerDtos);
        }
    }
}