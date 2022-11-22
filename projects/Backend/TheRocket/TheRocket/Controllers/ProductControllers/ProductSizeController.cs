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

    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeRepo repo;
        public ProductSizeController(IProductSizeRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public async Task<ActionResult<ProductSizeDto>> AssignSizesToProdcut(ProductSizeDto productSizeDto){
            SharedResponse<ProductSizeDto> response=await repo.AssignSizesToProdcut(productSizeDto);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest)return BadRequest(response.message);
            return Ok(response.data);
        }

         [HttpDelete]
        public async Task<ActionResult<ProductSizeDto>> UnAssignSizesToProdcut(ProductSizeDto productSizeDto){
            SharedResponse<ProductSizeDto> response=await repo.UnAssignSizesToProdcut(productSizeDto);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest)return BadRequest(response.message);
            return NoContent();
        }
    }
}