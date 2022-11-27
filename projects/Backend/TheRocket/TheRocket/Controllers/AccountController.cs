using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using TheRocket.Dtos.AccountDto;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.RepoInterfaces.UsersRepoInterfaces;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IAppUserRepo appUserRepo;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper, IAppUserRepo appUserRepo)
        {
            this.appUserRepo = appUserRepo;
            this.mapper = mapper;

            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {

            if (loginDto != null)
            {
                AppUser appUser = await userManager.FindByEmailAsync(loginDto.Email);
                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, loginDto.Password);
                    if (found)
                    {
                        var response = await getLoginResponse(appUser);
                        return Ok(response);
                    }

                }
            }
            return Unauthorized("Invalid Email or Password");

        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Signed Out");
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult> GetUserByToken()
        {
            var deSerializedResult = JsonConvert.SerializeObject(Request.Headers);
            var serializedResult = JsonConvert.DeserializeObject<Root>(deSerializedResult);
            var token = serializedResult.Authorization[0];
            token = token.Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var JsonToken = handler.ReadJwtToken(token);
            var userId = JsonToken.Claims.First(c => c.Type == "UserId").Value;
            SharedResponse<AppUserDto> result = await appUserRepo.GetById(userId);
            AppUser appUser=mapper.Map<AppUser>(result.data);
            var response=await getLoginResponse(appUser);
            if (result.status == Status.found) return Ok(response);
            return NotFound();
        }



        private async Task<LoginResponseDto> getLoginResponse(AppUser appUser)
        {
            LoginResponseDto response = new();
            AppUserDto appUserDto = mapper.Map<AppUserDto>(appUser);
            int AccountId = 0;
            var userRoles = await userManager.GetRolesAsync(appUser);
            response.UserId = appUser.Id;
            response.UserName = appUserDto.UserName;
            if (userRoles[0] == "Seller")
            {
                response.AccountId = appUserDto.Seller.SellerId;
                response.BrandName = appUserDto.Seller.BrandName;
                response.AccountType = "Seller";
                AccountId = appUser.Seller.SellerId;
            }

            if (userRoles[0] == "Buyer")
            {
                response.AccountId = appUserDto.Buyer.BuyerId;
                response.FirstName = appUserDto.Buyer.FirstName;
                response.LastName = appUserDto.Buyer.LastName;
                response.AccountType = "Buyer";
                AccountId = appUser.Buyer.BuyerId;

            }
            if (userRoles[0] == "Admin")
            {
                response.AccountId = appUserDto.Admin.AdminId;
                response.FirstName = appUserDto.Admin.FirstName;
                response.LastName = appUserDto.Admin.LastName;
                response.AccountType = "Admin";
                AccountId = appUser.Admin.AdminId;

            }
            List<Claim> claims = new();
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            string jwtToken = JwtTokenGenerator.Generate(
                userRoles,
                appUser.Id,
                AccountId,
                appUser.Email,
                appUser.UserName
                );
            // await signInManager.SignInWithClaimsAsync(appUser, loginDto.RememberMe, claims);
            response.JwtToken = jwtToken;
            return response;

        }
    }
}

public class Root
{
    public List<string> Accept { get; set; }
    public List<string> Connection { get; set; }
    public List<string> Host { get; set; }

    [JsonProperty("User-Agent")]
    public List<string> UserAgent { get; set; }

    [JsonProperty("Accept-Encoding")]
    public List<string> AcceptEncoding { get; set; }
    public List<string> Authorization { get; set; }
    public List<string> Cookie { get; set; }

    [JsonProperty("Postman-Token")]
    public List<string> PostmanToken { get; set; }
}


