
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using TheRocket.TheRocketDbContexts;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory SubCategory;
        private readonly TheRocketDbContext Context;

        public SubCategoryController(TheRocketDbContext context,ISubCategory subCategory)
        {
            this.SubCategory = subCategory;
            Context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(SubCategory.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var s = Context.SubCategories.FirstOrDefault(s => s.Id == id && s.IsDeleted == false);
            if (s != null)
                return Ok(await SubCategory.GetById(id));
            else
                return NotFound();
        }
      

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var p = Context.SubCategories.FirstOrDefault(p => p.Id == id && p.IsDeleted == false);
            if (p != null)
                return Ok(await SubCategory.Delete(id));
            else
                return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> Update(SubCategoryDto subCategory)
        {
            var s = Context.Plans.FirstOrDefault(s => s.Id == subCategory.Id && s.IsDeleted == false);
            if (s != null)
                return Ok(await SubCategory.Update(subCategory));
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategoryDto subCategory)
        {
            return Ok(await SubCategory.Create(subCategory));
        }
    }
}
