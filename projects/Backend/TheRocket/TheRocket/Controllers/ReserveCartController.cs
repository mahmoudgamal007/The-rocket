using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Buyer")]

    public class ReserveCartController : ControllerBase
    {

        private readonly IReserveCart repo;
        public ReserveCartController(IReserveCart repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReserveCartDto>>> GetAll()
        {
            SharedResponse<List<ReserveCartDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<ReserveCartDto>>> GetCartsByBuyerId([FromQuery] int BuyerId)
        {
            SharedResponse<List<ReserveCartDto>> response = await repo.GetCartByBuyerId(BuyerId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        // Get By ID
        [HttpGet("[action]")]
        public async Task<ActionResult<ReserveCartDto>> GetById([FromQuery] int id)
        {
            SharedResponse<ReserveCartDto> response = await repo.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        // Create ReserveCart
        [HttpPost]
        public async Task<ActionResult<ReserveCartDto>> PostReserveCart(ReserveCartDto ReserveCart)
        {
            SharedResponse<ReserveCartDto> response = await repo.Create(ReserveCart);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        //Update Action
        [HttpPut]
        public async Task<ActionResult<ReserveCartDto>> PutReserveCart([FromQuery] int id, ReserveCartDto ReserveCart)
        {
            SharedResponse<ReserveCartDto> response = await repo.Update(id, ReserveCart);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        //Delete Action
        [HttpDelete]
        public async Task<ActionResult<ReserveCartDto>> DeleteReserveCart([FromQuery] int id)
        {
            SharedResponse<ReserveCartDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}
