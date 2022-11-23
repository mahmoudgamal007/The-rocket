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
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepo repo;
        public LocationController(ILocationRepo repo)
        {
            this.repo = repo;
        }

       [HttpGet("[action]")]
        public async Task<ActionResult<List<LocationDto>>> GetLocationByUserId([FromQuery] String userId)
        {
            SharedResponse<List<LocationDto>> response = await repo.GetLocationsByUserId(userId);
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<List<LocationDto>>> GetAllLocations()
        
        {
            SharedResponse<List<LocationDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return response.data;
        }
       [HttpGet("[action]")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<LocationDto>> GetLocationById([FromQuery] int Id)
        {
            SharedResponse<LocationDto> response = await repo.GetById(Id);
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

        [HttpPut]
        public async Task<ActionResult<LocationDto>> PutLocation([FromQuery] int id, LocationDto Location)
        {
            SharedResponse<LocationDto> response = await repo.Update(id, Location);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<LocationDto>> DeleteLocation([FromQuery] int id)
        {
            SharedResponse<LocationDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }


    }
}