using Microsoft.AspNetCore.Mvc;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos.UserDtos;
using System.Net;
using System.Net.Http;
using System.Web;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;

namespace TheRocket.Controller
{
    [ApiController]
    [Route("Api/[Controller]")]
        [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo repo;
        public AdminController(IAdminRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AdminDto>> PostAdmin(AdminDto AdminDto)
        {
            if (AdminDto == null)
            {
                return BadRequest();
            }

            SharedResponse<AdminDto> response = await repo.Create(AdminDto);

            if (response.status == Status.createdAtAction)
                return Created(response.message, response.data);

            if (response.status == Status.badRequest)

                return BadRequest(response.message);

            return BadRequest();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<AdminDto>> GetAdminById([FromQuery] int Id)
        {
            SharedResponse<AdminDto> response = await repo.GetById(Id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet("[action]")]
        
        public async Task<ActionResult<AdminDto>> GetAdminByUserId([FromQuery] string AppUserId)
        {
            SharedResponse<AdminDto> response = await repo.GetByUserId(AppUserId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet]
        public async Task<ActionResult<List<AdminDto>>> GetAllAdmins()
        {
            SharedResponse<List<AdminDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        
        
        [HttpDelete]
        public async Task<ActionResult<AdminDto>> DeleteAdmin([FromQuery] int Id)
        {
            if (Id == 0) return BadRequest();
            var response = await repo.Delete(Id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<AdminDto>> PutAdmin([FromQuery] int Id, AdminDto adminDto)
        {
            if(Id!=adminDto.AdminId||adminDto==null)return BadRequest();
            var response =await repo.Update(Id,adminDto);
            if(response.status==Status.badRequest)return BadRequest();
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

    }
}