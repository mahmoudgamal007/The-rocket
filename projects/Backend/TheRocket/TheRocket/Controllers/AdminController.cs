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
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo repo;
        public AdminController(IAdminRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<AdminDto>> PostSeller(AdminDto AdminDto)
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


    }
}