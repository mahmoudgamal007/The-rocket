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
    public class AdminRepo : IAdminRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IAddressRepo addressRepo;
        private readonly IPhoneRepo phoneRepo;
        private readonly ILocationRepo locationRepo;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminRepo(TheRocketDbContext db, IMapper mapper, UserManager<AppUser> userManager,
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
        public async Task<SharedResponse<AdminDto>> Create(AdminDto model)
        {
            if (db.Sellers == null) return new SharedResponse<AdminDto>(Status.problem, null, "Entity set 'db.Admin' is null");
            SharedResponse<AddressDto> addressResponse;
            SharedResponse<PhoneDto> phoneResponse;
            SharedResponse<LocationDto> locationResponse;
            SharedResponse<IdentityResult> identityResponse;
            IdentityResult identityResult;
            string message = "";


            AppUser appUser = mapper.Map<AppUser>(model);
            Admin admin = mapper.Map<Admin>(model);

            if (appUser != null && admin != null)
            {
                identityResult = await userManager.CreateAsync(appUser, model.Password);
                if (identityResult.Succeeded)
                {
                    admin.AppUserId = appUser.Id;
                    db.Admins.Add(admin);
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
                        await db.SaveChangesAsync();
                        var roles = await roleManager.FindByNameAsync("Admin");
                        if (roles != null)
                            identityResult = await userManager.AddToRoleAsync(appUser, "Admin");
                        else throw new Exception("Admin Role not Found");
                        return new SharedResponse<AdminDto>(Status.createdAtAction, model, message);
                    }
                    catch (Exception ex)
                    {
                        if (admin != null)

                            await Delete(admin.Id);
                        if (model.Addresse != null)
                            addressResponse = await addressRepo.Delete(model.Addresse.Id);

                        if (model.PhoneNumber != null)
                            phoneResponse = await phoneRepo.Delete(model.PhoneNumber.Id);

                        if (model.Location != null)
                            locationResponse = await locationRepo.Delete(model.Location.Id);
                        identityResult = await userManager.DeleteAsync(appUser);
                        return new SharedResponse<AdminDto>(Status.badRequest, null, ex.ToString());
                    }

                }
                string identityReponse = JsonConvert.SerializeObject(identityResult);

                return new SharedResponse<AdminDto>(Status.badRequest, null, identityReponse);
            }
            return new SharedResponse<AdminDto>(Status.badRequest, null);

        }

        public async Task<SharedResponse<AdminDto>> Delete(int Id)
        {
            if (db.Admins == null)
            {
                return new SharedResponse<AdminDto>(Status.notFound, null);

            }
            var admin = await db.Admins.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (admin == null)
            {
                return new SharedResponse<AdminDto>(Status.notFound, null);
            }
            db.Admins.Remove(admin);
            await db.SaveChangesAsync();
            return new SharedResponse<AdminDto>(Status.noContent, null);
        }

        public Task<List<SharedResponse<AdminDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<AdminDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<AdminDto>> Update(int Id, AdminDto model)
        {
            throw new NotImplementedException();
        }


    }
}