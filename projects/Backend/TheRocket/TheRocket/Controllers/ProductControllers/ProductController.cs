using AutoMapper;
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
    [Authorize(Roles = "Seller")]
    public class ProductController : ControllerBase
    {
        private readonly IProdcutRepo repo;
        private readonly IMapper mapper;
        public ProductController(IProdcutRepo repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }

        [AllowAnonymous]

        [HttpGet("[action]")]
        public async Task<ActionResult<ProductDto>> GetProducts([FromQuery] ProductQueryParameter queryParameter)
        {
            var response = await repo.GetProductsWithFilters(queryParameter);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            SharedResponse<List<ProductDto>> response = await repo.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }

        [HttpGet("action")]
        [AllowAnonymous]
        public async Task<ActionResult<List<ProductDto>>> GetProductsBySellerId([FromQuery] int sellerId)
        {
            if (sellerId == 0) return BadRequest();
            var response = await repo.GetProductsBySellerId(sellerId);
            if (response.status == Status.found) return Ok(response);
            return NotFound();
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> GetProdcutById([FromQuery] int id)
        {
            SharedResponse<ProductDto> response = await repo.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }



        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct([FromBody] AddProductDto addProduct)
        {
            ProductDto product = mapper.Map<ProductDto>(addProduct);
            foreach (int id in addProduct.ColorIds)
            {
                product.Colors.Add(new ColorDto() { Id = id });
            }
            foreach (int id in addProduct.SizeIds)
            {
                product.Sizes.Add(new SizeDto() { Id = id });
            }
            if(addProduct.ImgUrls!=null)
            foreach (string url in addProduct.ImgUrls)
            {
                product.Imgs.Add(new ProductImgUrlDto() { Url = url });
            }
            SharedResponse<ProductDto> response = await repo.Create(product);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> PutProduct([FromQuery] int id, ProductDto Product)
        {
            SharedResponse<ProductDto> response = await repo.Update(id, Product);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin,Seller")]
        public async Task<ActionResult<ProductDto>> DeleteProduct([FromQuery] int id)
        {
            SharedResponse<ProductDto> response = await repo.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
    }
}