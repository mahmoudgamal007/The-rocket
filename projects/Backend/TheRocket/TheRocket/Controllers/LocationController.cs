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
    [Authorize(Roles = "Buyer,Seller")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepo repo;
        public LocationController(ILocationRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> GetLocationByUserId(String userId)
        {
            SharedResponse<List<LocationDto>> response = await repo.GetLocationsByUserId(userId);
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }

        [HttpPost]
        public async Task<ActionResult<LocationDto>> PostLocation(LocationDto Location)
        {
            SharedResponse<LocationDto> response = await repo.Create(Location);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LocationDto>> PutLocation(int id, LocationDto Location)
        {
            SharedResponse<LocationDto> response = await repo.Update(id, Location);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationDto>> DeleteLocation(int id)
        {
            SharedResponse<LocationDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}