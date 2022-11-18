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
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepo repo;
        public SellerController(ISellerRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<SellerDto>> PostSeller(SellerDto sellerDto)
        {
            if (sellerDto == null)
            {
                return BadRequest();
            }

            SharedResponse<SellerDto> response = await repo.Create(sellerDto);

            if(response.status==Status.createdAtAction)
            return Created(response.message,response.data);

            if(response.status==Status.badRequest)
            
            return BadRequest(response.message);

            return BadRequest();
        }
    }
}