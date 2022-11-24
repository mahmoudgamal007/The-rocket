using Microsoft.AspNetCore.Mvc;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos.UserDtos;
using System.Net;
using System.Net.Http;
using System.Web;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;
using TheRocket.RepoInterfaces.UsersRepoInterfaces;

namespace TheRocket.Controller
{
    [ApiController]
    [Route("Api/[Controller]")]

    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepo repo;
        public AppUserController(IAppUserRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AppUserDto>> PostAppUser(AppUserDto AppUserDto)
        {
            if (AppUserDto == null)
            {
                return BadRequest();
            }

            var response = await repo.Create(AppUserDto);

            if (response.status == Status.createdAtAction)
                return Created(response.message, response.data);

            return BadRequest(response.message);
        }

        // [HttpGet("[action]")]
        // public async Task<ActionResult<AppUserDto>> GetAppUserById([FromQuery] int Id)
        // {
        //     SharedResponse<AppUserDto> response = await repo.GetById(Id);
        //     if (response.status == Status.notFound) return NotFound();
        //     return Ok(response.data);

        // }

        [HttpGet("[action]")]
        
        public async Task<ActionResult<AppUserDto>> GetAppUserByUserId([FromQuery] string AppUserId)
        {
            SharedResponse<AppUserDto> response = await repo.GetById(AppUserId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet]
        public async Task<ActionResult<List<AppUserDto>>> GetAllAppUsers()
        {
            SharedResponse<List<AppUserDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        
        
        // [HttpDelete]
        // public async Task<ActionResult<AppUserDto>> DeleteAppUser([FromQuery] string Id)
        // {
        //     if (Id ==null) return BadRequest();
        //     var response = await repo.Delete(Id);
        //     if (response.status == Status.notFound) return NotFound();
        //     return NoContent();
        // }
        // [HttpPut]
        // public async Task<ActionResult<AppUserDto>> PutAppUser([FromQuery] string Id, AppUserDto AppUserDto)
        // {
        //     if(Id!=AppUserDto.Id||AppUserDto==null)return BadRequest();
        //     var response =await repo.Update(Id,AppUserDto);
        //     if(response.status==Status.problem)return Problem(response.message);
        //     return NoContent();
        // }

    }
}