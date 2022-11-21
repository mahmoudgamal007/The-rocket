using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //[Authorize(Roles="Admin,Seller")]


    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory repo;

        public SubCategoryController(ISubCategory repo)
        {
            this.repo = repo;

        }
        // Get All SubCategories
        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll(){
         SharedResponse<List<SubCategoryDto>> response= await repo.GetAll();
         if(response.status==Status.notFound)return NotFound();
         return Ok( response.data);
        }
        // Get By ID
        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDto>> GetById(int id){
         SharedResponse<SubCategoryDto> response= await repo.GetById(id);
         if(response.status==Status.notFound)return NotFound();
         return Ok(response.data);
        }
        // Create SubCategory
        [HttpPost]
        public async Task<ActionResult<SubCategoryDto>> PostSubCategory(SubCategoryDto SubCategory){
            SharedResponse<SubCategoryDto> response=await repo.Create(SubCategory);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        //Update Action
        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryDto>> PutSubCategory(int id,SubCategoryDto SubCategory){
            SharedResponse<SubCategoryDto> response=await repo.Update(id,SubCategory);
            if(response.status==Status.badRequest)return BadRequest();
            else if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

       //Delete Action
        [HttpDelete("{id}")]
         public async Task<ActionResult<SubCategoryDto>> DeleteSubCategory(int id){
            SharedResponse<SubCategoryDto> response=await repo.Delete(id);
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
         } 
    }
}
