using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> PostRole(string name)
        {
            try
            {
                if (name != null)
                {
                    IdentityRole role = new();
                    role.Name = name;
                    IdentityResult result = await roleManager.CreateAsync(role);
                    return Created("", role);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString);
            }
        }


        [HttpGet]
        public async Task<ActionResult<List<IdentityRole>>> GetAllRoles()
        {
            var response = roleManager.Roles;
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<IdentityRole>> GetRoleByName(IdentityRole role)
        {

            try
            {
                await roleManager.UpdateAsync(role);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.TargetSite);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<IdentityRole>> DeleteRole([FromQuery] string Name)
        {
            try
            {

                var role = await roleManager.FindByNameAsync(Name);
                if (role == null) return NotFound();
                await roleManager.DeleteAsync(role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}