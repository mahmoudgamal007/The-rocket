using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TheRocket.Dtos.AccountDto;
using TheRocket.Entities.Users;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
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
                        var userRoles = await userManager.GetRolesAsync(appUser);

                        List<Claim> claims = new(){
                            new Claim("UserName",appUser.UserName)
                        };
                        foreach (var role in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));

                        }
                        string jwtToken = JwtTokenGenerator.Generate(claims);
                        await signInManager.SignInWithClaimsAsync(appUser, loginDto.RememberMe, claims);
                        return Ok(jwtToken);
                    }
                }

            }
            return Unauthorized("Invalid Email or Password");
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok("Signed Out");
        }
    }
}