using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    [Authorize]

    public class AddressController : ControllerBase
    {
        private readonly IAddressRepo repo;
        public AddressController(IAddressRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<AddressDto>>> GetAddressByUserId([FromQuery] String userId)
        {
            SharedResponse<List<AddressDto>> response = await repo.GetAddressesByUserId(userId);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<AddressDto>>> GetAddresses()
        {
            SharedResponse<List<AddressDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<AddressDto>> GetAddressById([FromQuery] int id)
        {
            SharedResponse<AddressDto> response = await repo.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> PostAddress(AddressDto address)
        {
            SharedResponse<AddressDto> response = await repo.Create(address);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        [HttpPut]
        public async Task<ActionResult<AddressDto>> PutAddress([FromQuery] int id, AddressDto address)
        {
            SharedResponse<AddressDto> response = await repo.Update(id, address);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<AddressDto>> DeleteAddress([FromQuery] int id)
        {
            SharedResponse<AddressDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}