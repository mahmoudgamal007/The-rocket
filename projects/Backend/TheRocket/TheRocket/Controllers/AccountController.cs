using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TheRocket.Dtos.AccountDto;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
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

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.mapper = mapper;

            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            LoginResponseDto response = new();
            if (loginDto != null)
            {
                AppUser appUser = await userManager.FindByEmailAsync(loginDto.Email);
                if (appUser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appUser, loginDto.Password);
                    if (found)
                    {
                        AppUserDto appUserDto = mapper.Map<AppUserDto>(appUser);
                        int AccountId=0;
                        var userRoles = await userManager.GetRolesAsync(appUser);
                        response.UserId = appUser.Id;
                        response.UserName = appUserDto.UserName;
                        if (userRoles[0] == "Seller")
                        {
                            response.AccountId = appUserDto.Seller.SellerId;
                            response.BrandName = appUserDto.Seller.BrandName;
                            response.AccountType = "Seller";
                            AccountId=appUser.Seller.SellerId;
                        }

                        if (userRoles[0] == "Buyer")
                        {
                            response.AccountId = appUserDto.Buyer.BuyerId;
                            response.FirstName = appUserDto.Buyer.FirstName;
                            response.LastName = appUserDto.Buyer.LastName;
                            response.AccountType = "Buyer";
                            AccountId=appUser.Buyer.BuyerId;

                        }
                        if (userRoles[0] == "Admin")
                        {
                            response.AccountId = appUserDto.Admin.AdminId;
                            response.FirstName = appUserDto.Admin.FirstName;
                            response.LastName = appUserDto.Admin.LastName;
                            response.AccountType = "Admin";
                            AccountId=appUser.Admin.AdminId;

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
                        await signInManager.SignInWithClaimsAsync(appUser, loginDto.RememberMe, claims);
                        response.JwtToken = jwtToken;
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
    }
}