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
    [Authorize(Roles = "Seller")]

    public class SellerController : ControllerBase
    {
        private readonly ISellerRepo repo;
        public SellerController(ISellerRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<SellerDto>> PostSeller(SellerDto sellerDto)
        {
            if (sellerDto == null)
            {
                return BadRequest();
            }

            SharedResponse<SellerDto> response = await repo.Create(sellerDto);

            if (response.status == Status.createdAtAction)
                return Created(response.message, response.data);

            if (response.status == Status.badRequest)

                return BadRequest(response.message);

            return BadRequest();
        }

        [HttpGet("[action]")]
        [AllowAnonymous]

        public async Task<ActionResult<SellerDto>> GetSellerById([FromQuery] int Id)
        {
            SharedResponse<SellerDto> response = await repo.GetById(Id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet("[action]")]

        public async Task<ActionResult<SellerDto>> GetSellerByUserId([FromQuery] string AppUserId)
        {
            SharedResponse<SellerDto> response = await repo.GetByUserId(AppUserId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<List<SellerDto>>> GetAllSellers()
        {
            SharedResponse<List<SellerDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }


        [HttpDelete]
        [Authorize(Roles = "Admin,Seller")]

        public async Task<ActionResult<SellerDto>> DeleteSeller([FromQuery] int Id)
        {
            if (Id == 0) return BadRequest();
            var response = await repo.Delete(Id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<SellerDto>> PutSeller([FromQuery] int Id, SellerDto SellerDto)
        {
            if (Id != SellerDto.SellerId || SellerDto == null) return BadRequest();
            var response = await repo.Update(Id, SellerDto);
            if (response.status == Status.badRequest) return BadRequest();
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }


    }
}