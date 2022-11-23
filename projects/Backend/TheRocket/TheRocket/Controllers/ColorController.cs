using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos.UserDtos;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Users;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    // [Authorize(Roles="Buyer,Seller")]

    public class ColorController : ControllerBase
    {
        private readonly IColorRepo repo;
        public ColorController(IColorRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ColorDto>> AllColors(){
            SharedResponse<List<ColorDto>> response=await repo.GetAll();
            if(response.status==Status.notFound)return NotFound();
            return Ok(response.data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColorDto>> GetColorById(int id){
            SharedResponse<ColorDto> response=await repo.GetById(id);
            if(response.status==Status.notFound)return NotFound();
            return Ok(response.data);
        }

        [HttpPost]
        public async Task<ActionResult<ColorDto>> PostColor(ColorDto color){
            SharedResponse<ColorDto> response=await repo.Create(color);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest) return BadRequest(response.message);
            if(response.status==Status.found)return Ok(response);
            return Ok(response.data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColorDto>> PutColor(int id,ColorDto color){
            SharedResponse<ColorDto> response=await repo.Update(id,color);
            if(response.status==Status.badRequest)return BadRequest();
            else if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<ColorDto>> DeleteColor(int id){
            SharedResponse<ColorDto> response=await repo.Delete(id);
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
         } 
    }
}