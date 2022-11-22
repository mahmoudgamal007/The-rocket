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
    [Authorize(Roles="Seller")]

    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorRepo repo;
        public ProductColorController(IProductColorRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<ProductColorDto>> AssignColorsToProdcut(ProductColorDto productColorDto){
            SharedResponse<ProductColorDto> response=await repo.AssignColorsToProdcut(productColorDto);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest)return BadRequest(response.message);
            return Ok(response.data);
        }

         [HttpDelete]
        public async Task<ActionResult<ProductColorDto>> UnAssignColorsToProdcut(ProductColorDto productColorDto){
            SharedResponse<ProductColorDto> response=await repo.UnAssignColorsToProdcut(productColorDto);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest)return BadRequest(response.message);
            return NoContent();
        }
    }
}