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
        [Authorize(Roles = "Buyer")]

    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepo repo;
        public BuyerController(IBuyerRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BuyerDto>> PostBuyer(BuyerDto BuyerDto)
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

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<BuyerDto>> GetBuyerById([FromQuery] int Id)
        {
            SharedResponse<BuyerDto> response = await repo.GetById(Id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

         [HttpGet("[action]")]
        public async Task<ActionResult<BuyerDto>> GetBuyerByUserId([FromQuery] string AppUserId)
        {
            SharedResponse<BuyerDto> response = await repo.GetByUserId(AppUserId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<List<BuyerDto>>> GetAllBuyers()
        {
            SharedResponse<List<BuyerDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        
        
        [HttpDelete]
        [Authorize(Roles = "Admin,Buyer")]

        public async Task<ActionResult<BuyerDto>> DeleteBuyer([FromQuery] int Id)
        {
            if (Id == 0) return BadRequest();
            var response = await repo.Delete(Id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<BuyerDto>> PutBuyer([FromQuery] int Id, BuyerDto BuyerDto)
        {
            if(Id!=BuyerDto.BuyerId||BuyerDto==null)return BadRequest();
            var response =await repo.Update(Id,BuyerDto);
            if(response.status==Status.badRequest)return BadRequest();
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

 
    }
}