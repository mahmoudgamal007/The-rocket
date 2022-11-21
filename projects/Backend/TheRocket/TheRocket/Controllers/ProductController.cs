using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.QueryParameters;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProdcutRepo repo;
        public ProductController(IProdcutRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProducts([FromQuery] ProductQueryParameter queryParameter){
            SharedResponse<List<ProductDto>> response=await repo.GetProductsWithFilters(queryParameter);
            if(response.status==Status.notFound)return NotFound();
            return Ok(response.data);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto Product){
            SharedResponse<ProductDto> response=await repo.Create(Product);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> PutProduct(int id,ProductDto Product){
            SharedResponse<ProductDto> response=await repo.Update(id,Product);
            if(response.status==Status.badRequest)return BadRequest();
            else if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<ProductDto>> DeleteProduct(int id){
            SharedResponse<ProductDto> response=await repo.Delete(id);
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
         } 
    }
}