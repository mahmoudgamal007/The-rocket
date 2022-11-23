using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]


    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory repo;

        public SubCategoryController(ISubCategory repo)
        {
            this.repo = repo;

        }
        // Get All SubCategories
        [HttpGet]
        [Authorize(Roles = "Admin,Seller")]

        public async Task<ActionResult<List<SubCategoryDto>>> GetAll()
        {
            SharedResponse<List<SubCategoryDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        // Get By ID
        [HttpGet("[action]")]
        public async Task<ActionResult<SubCategoryDto>> GetById([FromQuery] int id)
        {
            SharedResponse<SubCategoryDto> response = await repo.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        // Create SubCategory
        [HttpPost]
        public async Task<ActionResult<SubCategoryDto>> PostSubCategory(SubCategoryDto SubCategory)
        {
            SharedResponse<SubCategoryDto> response = await repo.Create(SubCategory);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        //Update Action
        [HttpPut]

        public async Task<ActionResult<SubCategoryDto>> PutSubCategory([FromQuery] int id, SubCategoryDto SubCategory)
        {
            SharedResponse<SubCategoryDto> response = await repo.Update(id, SubCategory);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        //Delete Action
        [HttpDelete]

        public async Task<ActionResult<SubCategoryDto>> DeleteSubCategory([FromQuery] int id)
        {
            SharedResponse<SubCategoryDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}
