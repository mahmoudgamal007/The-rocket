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
            var result = await userManager.CreateAsync(appUser,model.Password);
            if (result.Succeeded)
            {
                LoginResponseDto response = new();
                model = mapper.Map<AppUserDto>(appUser);
                if (model.AccountType == AccountType.Admin)
                {
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    response.AccountId = appUser.Admin.AdminId;
                    response.AccountType = "Admin";

                }
                if (model.AccountType == AccountType.Seller)
                {
                    await userManager.AddToRoleAsync(appUser, "Seller");
                    response.AccountId = model.Seller.SellerId;
                    response.AccountType = "Seller";
                    response.BrandName = model.Seller.BrandName;


                }
                if (model.AccountType == AccountType.Buyer)
                {
                    await userManager.AddToRoleAsync(appUser, "Buyer");
                    response.AccountId = model.Buyer.BuyerId;
                    response.AccountType = "Buyer";
                }
                response.UserName = model.UserName;
                response.FirstName = model.Admin.FirstName ?? model.Buyer.FirstName;
                response.FirstName = model.Admin.LastName ?? model.Buyer.LastName;
                response.UserId = appUser.Id;
                var token = JwtTokenGenerator.Generate(new List<string>() { response.AccountType });
                response.JwtToken = token;
                return new SharedResponse<LoginResponseDto>(Status.createdAtAction, response);
            }
            string identityReponse = JsonConvert.SerializeObject(result);

            return new SharedResponse<LoginResponseDto>(Status.problem, null, identityReponse);


        }

        public Task<SharedResponse<AppUserDto>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<List<AppUserDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<AppUserDto>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SharedResponse<AppUserDto>> Update(int Id, AppUserDto model)
        {
            throw new NotImplementedException();
        }
    }
}