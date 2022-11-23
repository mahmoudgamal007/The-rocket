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
    public class SellerRepo : ISellerRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IAddressRepo addressRepo;
        private readonly IPhoneRepo phoneRepo;
        private readonly ILocationRepo locationRepo;
        private readonly RoleManager<IdentityRole> roleManager;

        public SellerRepo(TheRocketDbContext db, IMapper mapper, UserManager<AppUser> userManager,
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
        public async Task<SharedResponse<SellerDto>> Create(SellerDto model)
        {
            if (db.Sellers == null) return new SharedResponse<SellerDto>(Status.problem, null, "Entity set 'db.Seller' is null");
            SharedResponse<AddressDto> addressResponse;
            SharedResponse<PhoneDto> phoneResponse;
            SharedResponse<LocationDto> locationResponse;
            SharedResponse<IdentityResult> identityResponse;
            IdentityResult identityResult;
            string message = "";


            AppUser appUser = mapper.Map<AppUser>(model);
            Seller seller = mapper.Map<Seller>(model);

            if (appUser != null && seller != null)
            {
                identityResult = await userManager.CreateAsync(appUser, model.Password);
                if (identityResult.Succeeded)
                {
                    model = mapper.Map<SellerDto>(appUser);
                    seller.AppUserId = appUser.Id;
                    db.Sellers.Add(seller);
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

                        var roles = await roleManager.FindByNameAsync("Seller");
                        if (roles != null)
                        {
                            await db.SaveChangesAsync();
                            model = mapper.Map<SellerDto>(seller);
                            model.UserName = appUser.UserName;
                            model.Email = appUser.Email;
                            identityResult = await userManager.AddToRoleAsync(appUser, "Seller");
                        }

                        else
                        {
                            db.Sellers.Remove(seller);
                            throw new Exception("Seller Role not Found");
                        }
                        return new SharedResponse<SellerDto>(Status.createdAtAction, model, message);
                    }
                    catch (Exception ex)
                    {
                        if (seller != null)
                            await Delete(seller.SellerId);

                        if (model.Addresse != null)
                            await addressRepo.Delete(model.Addresse.Id);

                        if (model.PhoneNumber != null)
                            await phoneRepo.Delete(model.PhoneNumber.Id);

                        if (model.Location != null)
                            await locationRepo.Delete(model.Location.Id);

                        await userManager.DeleteAsync(appUser);
                        return new SharedResponse<SellerDto>(Status.badRequest, null, ex.ToString());
                    }

                }
                string identityReponse = JsonConvert.SerializeObject(identityResult);

                return new SharedResponse<SellerDto>(Status.badRequest, null, identityReponse);
            }
            return new SharedResponse<SellerDto>(Status.badRequest, null);

        }

        public async Task<SharedResponse<SellerDto>> Delete(int Id)
        {
            if (db.Sellers == null)
            {
                return new SharedResponse<SellerDto>(Status.notFound, null);

            }
            var seller = await db.Sellers.Where(a => a.SellerId == Id).FirstOrDefaultAsync();
            if (seller == null)
            {
                return new SharedResponse<SellerDto>(Status.notFound, null);
            }
            db.Sellers.Remove(seller);
            await db.SaveChangesAsync();

            return new SharedResponse<SellerDto>(Status.noContent, null);
        }


<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD:projects/Backend/TheRocket/TheRocket/Repositories/SellerRepo.cs
        public Task<SharedResponse<SellerDto>> GetById(int Id)
=======
        public async Task<SharedResponse<SellerDto>> GetById(int Id)
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9:projects/Backend/TheRocket/TheRocket/Repositories/UserRepos/SellerRepo.cs
=======
        public async Task<SharedResponse<SellerDto>> GetById(int Id)
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
        public async Task<SharedResponse<SellerDto>> GetById(int Id)
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
        {

            if (db.Sellers == null)
                return new SharedResponse<SellerDto>(Status.notFound, null);
            var Admin = await db.Sellers.Where(a => a.SellerId == Id).FirstOrDefaultAsync();
            SellerDto SellerDto = mapper.
            Map<SellerDto>(Admin);
            return new SharedResponse<SellerDto>(Status.found, SellerDto);

        }

        public async Task<SharedResponse<SellerDto>> GetByUserId(string AppUserId)
        {
            if (db.Sellers == null)
                return new SharedResponse<SellerDto>(Status.notFound, null);
            var Sellers = await db.Sellers.Where(a => a.AppUserId == AppUserId).FirstOrDefaultAsync();
            SellerDto SellerDto = mapper.
            Map<SellerDto>(Sellers);
            return new SharedResponse<SellerDto>(Status.found, SellerDto);
        }

        public bool IsExists(int Id)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD:projects/Backend/TheRocket/TheRocket/Repositories/SellerRepo.cs
            return (db.Sellers?.Any(a => a.Id == Id)).GetValueOrDefault();
=======
            return (db.Sellers?.Any(a => a.SellerId == Id)).GetValueOrDefault();
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9:projects/Backend/TheRocket/TheRocket/Repositories/UserRepos/SellerRepo.cs
=======
            return (db.Sellers?.Any(a => a.SellerId == Id)).GetValueOrDefault();
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
            return (db.Sellers?.Any(a => a.SellerId == Id)).GetValueOrDefault();
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
        }

        public async Task<SharedResponse<SellerDto>> Update(int Id, SellerDto model)
        {
            if (Id != model.SellerId)
            {
                return new SharedResponse<SellerDto>(Status.badRequest, null);
            }

            Admin admin = mapper.Map<Admin>(model);

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                if (IsExists(Id))
                    await db.SaveChangesAsync();
                else
                    return new SharedResponse<SellerDto>(Status.notFound, null);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }

            return new SharedResponse<SellerDto>(Status.noContent, null);
        }

        public async Task<SharedResponse<List<SellerDto>>> GetAll()
        {
            if (db.Sellers == null)
                return new SharedResponse<List<SellerDto>>(Status.notFound, null);
            var Sellers = await db.Sellers.ToListAsync();
            List<SellerDto> SellerDtos = mapper.
            Map<List<SellerDto>>(Sellers);
            return new SharedResponse<List<SellerDto>>(Status.found, SellerDtos);
        }

    }
}