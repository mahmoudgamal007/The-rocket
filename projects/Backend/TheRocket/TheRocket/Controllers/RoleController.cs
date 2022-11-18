using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    [Authorize(Roles="Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> PostRole(string name){
            try{
                if(name!=null){
                    IdentityRole role=new();
                    role.Name=name;
                    IdentityResult result=await roleManager.CreateAsync(role);
                    return Created("",role);
                }
                return BadRequest();
            }
            catch(Exception ex){
                return BadRequest(ex.ToString);
            }
        }
    }
}