
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TheRocket.TheRocketDbContexts;
using TheRocket.Repositories;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="Admin,Seller")]


    public class SubCategoryController : ControllerBase
    {
        private readonly SubCategoryRepo repo;

        public SubCategoryController(SubCategoryRepo repo)
        {
            this.repo = repo;

        }
        [HttpGet]
        public async Task<ActionResult<List<SubCategoryDto>>> GetAll(){
         SharedResponse<List<SubCategoryDto>> response= await repo.GetAll();
         if(response.status==Status.notFound)return NotFound();
         return response.data;
        }
          [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDto>> GetById(int id){
         SharedResponse<SubCategoryDto> response= await repo.GetById(id);
         if(response.status==Status.notFound)return NotFound();
         return Ok(response.data);
        }

        [HttpPost]
        public async Task<ActionResult<SubCategoryDto>> PostSubCategory(SubCategoryDto SubCategory){
            SharedResponse<SubCategoryDto> response=await repo.Create(SubCategory);
            if(response.status==Status.problem)return Problem(response.message);
            if(response.status==Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubCategoryDto>> PutSubCategory(int id,SubCategoryDto SubCategory){
            SharedResponse<SubCategoryDto> response=await repo.Update(id,SubCategory);
            if(response.status==Status.badRequest)return BadRequest();
            else if(response.status==Status.notFound)return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
         public async Task<ActionResult<SubCategoryDto>> DeleteSubCategory(int id){
            SharedResponse<SubCategoryDto> response=await repo.Delete(id);
            if(response.status==Status.notFound)return NotFound();
            return NoContent();
         } 
    }
}
