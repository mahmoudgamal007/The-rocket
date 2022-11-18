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
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepo repo;
        public BuyerController(IBuyerRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<BuyerDto>> PostSeller(BuyerDto BuyerDto)
        {
            if (BuyerDto == null)
            {
                return BadRequest();
            }

            SharedResponse<BuyerDto> response = await repo.Create(BuyerDto);

            if(response.status==Status.createdAtAction)
            return Created(response.message,response.data);

            if(response.status==Status.badRequest)
            
            return BadRequest(response.message);

            return BadRequest();
        }
    }
}