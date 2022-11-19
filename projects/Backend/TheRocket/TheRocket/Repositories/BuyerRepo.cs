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
            if (db.Sellers == null) return new SharedResponse<BuyerDto>(Status.problem, null, "Entity set 'db.Buyer' is null");
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
                            await Delete(buyer.Id);

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
            if (db.Admins == null)
            {
                return new SharedResponse<BuyerDto>(Status.notFound, null);

            }
            var admin = await db.Admins.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (admin == null)
            {
                return new SharedResponse<BuyerDto>(Status.notFound, null);
            }
            db.Admins.Remove(admin);
            await db.SaveChangesAsync();
            return new SharedResponse<BuyerDto>(Status.noContent, null);
        }

       

        public Task<SharedResponse<BuyerDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<BuyerDto>> Update(int Id, BuyerDto model)
        {
            throw new NotImplementedException();
        }

        Task<SharedResponse<List<BuyerDto>>> IBaseRepo<SharedResponse<BuyerDto>, SharedResponse<List<BuyerDto>>, BuyerDto>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}