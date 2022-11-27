using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using TheRocket.Dtos.AccountDto;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.RepoInterfaces.UsersRepoInterfaces;
using TheRocket.Shared;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Repositories.UserRepos
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly TheRocketDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AppUserRepo(TheRocketDbContext db, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.db = db;

        }


        public async Task<SharedResponse<LoginResponseDto>> Create(AppUserDto model)
        {
            if (model == null)
                return new SharedResponse<LoginResponseDto>(Status.badRequest, null);

            if (model.AccountType == AccountType.Admin) { model.Seller = null; model.Buyer = null; }
            if (model.AccountType == AccountType.Seller) { model.Admin = null; model.Buyer = null; }
            if (model.AccountType == AccountType.Buyer) { model.Admin = null; model.Seller = null; }
            if (model.Seller == null && model.Buyer == null && model.Admin == null)
                return new SharedResponse<LoginResponseDto>(Status.badRequest, null, "Shoul enter data for one Account and only one");
            AppUser appUser = mapper.Map<AppUser>(model);
            appUser.Id=Guid.NewGuid().ToString();
            var result = await userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                LoginResponseDto response = new();
                AccountType type = model.AccountType;
                model = mapper.Map<AppUserDto>(appUser);
                if (type == AccountType.Admin)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    response.AccountId = appUser.Admin.AdminId;
                    response.AccountType = "Admin";
                    response.FirstName = model.Admin.FirstName;
                    response.LastName = model.Admin.LastName;

                }
                if (type == AccountType.Seller)
                {
                    await userManager.AddToRoleAsync(appUser, "Seller");
                    response.AccountId = model.Seller.SellerId;
                    response.AccountType = "Seller";
                    response.BrandName = model.Seller.BrandName;


                }
                if (type == AccountType.Buyer)
                {
                    await userManager.AddToRoleAsync(appUser, "Buyer");
                    response.AccountId = model.Buyer.BuyerId;
                    response.AccountType = "Buyer";
                    response.FirstName = model.Buyer.FirstName;
                    response.LastName = model.Buyer.LastName;
                }
                response.UserName = model.UserName;
                response.UserId = appUser.Id;
                var token = JwtTokenGenerator.Generate(
                    new List<string>() { response.AccountType },
                    response.UserId,
                    response.AccountId,
                    appUser.Email,
                    response.UserName
                    );
                response.JwtToken = token;
                return new SharedResponse<LoginResponseDto>(Status.createdAtAction, response);
            }
            string identityReponse = JsonConvert.SerializeObject(result);

            return new SharedResponse<LoginResponseDto>(Status.problem, null, identityReponse);


        }

        public async Task<SharedResponse<bool>> Delete(string Id)
        {
            AppUser appUser = await userManager.FindByIdAsync(Id);
            if (appUser != null)
            {
                await userManager.DeleteAsync(appUser);
                return new SharedResponse<bool>(Status.noContent, true);
            }
            return new SharedResponse<bool>(Status.problem, false);
        }

        public async Task<SharedResponse<List<AppUserDto>>> GetAll()
        {
            var appUsers = userManager.Users.ToList();
            var appUserDtos = mapper.Map<List<AppUserDto>>(appUsers);
            if (appUsers.Count() < 1) return new SharedResponse<List<AppUserDto>>(Status.notFound, appUserDtos);
            return new SharedResponse<List<AppUserDto>>(Status.found, appUserDtos);
        }

      

        public async Task<SharedResponse<AppUserDto>> GetById(string id)
        {
            AppUser appUser = await userManager.FindByIdAsync(id);
            if (appUser != null)
            {
                var appUserDto = mapper.Map<AppUserDto>(appUser);
                return new SharedResponse<AppUserDto>(Status.found, appUserDto);
            }
            return new SharedResponse<AppUserDto>(Status.notFound, null);
        }

        public async Task<bool> IsExist(string email)
        {
           var check=await userManager.FindByEmailAsync(email);
           if(check!=null) return true;
           return false;
        }


        // public async Task<SharedResponse<AppUserDto>> Update(string Id, AppUserDto model)
        // {
        //     AppUser appUser = mapper.Map<AppUser>(model);
        //     IdentityResult result = await userManager.UpdateAsync(appUser);
        //     if (result.Succeeded) return new SharedResponse<AppUserDto>(Status.noContent, null);
        //     var message=JsonConvert.SerializeObject(result);
        //     return new SharedResponse<AppUserDto>(Status.problem,null,message);
        // }
    }
}