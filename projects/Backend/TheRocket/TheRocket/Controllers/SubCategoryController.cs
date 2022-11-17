
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategory SubCategory;
        public SubCategoryController(ISubCategory subCategory)
        {
            this.SubCategory = subCategory;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(SubCategory.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(SubCategory.GetById(id));

        }
        [HttpPut]
        public async Task<IActionResult> Update(SubCategory subCategory)
        {
            return Ok(SubCategory.Update(subCategory));
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            return Ok(SubCategory.Add(subCategory));
        }
    }
}
