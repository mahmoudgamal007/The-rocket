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
    [Authorize(Roles = "Seller")]

    public class ProductImgUrlController : ControllerBase
    {
        private readonly IProductImgUrlRepo repo;
        public ProductImgUrlController(IProductImgUrlRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        
        public async Task<ActionResult<ProductImgUrlDto>> AllProductImgUrls()
        {
            SharedResponse<List<ProductImgUrlDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet("[action]")]
        [Authorize(Roles ="Admin")]

        public async Task<ActionResult<ProductImgUrlDto>> GetProductImgUrlById([FromQuery] int id)
        
        {
            SharedResponse<ProductImgUrlDto> response = await repo.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet("[action]")]

        public async Task<ActionResult<List<ProductImgUrlDto>>> GetProductImgUrlByProduct([FromQuery] int id)
        {
            SharedResponse<List<ProductImgUrlDto>> response = await repo.GetImgUrlByProductId(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpPost]
        public async Task<ActionResult<ProductImgUrlDto>> PostProductImgUrl(ProductImgUrlDto ProductImgUrl)
        {
            SharedResponse<ProductImgUrlDto> response = await repo.Create(ProductImgUrl);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            if (response.status == Status.found) return Ok(response);
            return Ok(response.data);
        }

        [HttpPut]
        public async Task<ActionResult<ProductImgUrlDto>> PutProductImgUrl([FromQuery] int id, ProductImgUrlDto ProductImgUrl)
        {
            SharedResponse<ProductImgUrlDto> response = await repo.Update(id, ProductImgUrl);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles ="Admin,Seller")]

        public async Task<ActionResult<ProductImgUrlDto>> DeleteProductImgUrl([FromQuery] int id)
        {
            SharedResponse<ProductImgUrlDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}