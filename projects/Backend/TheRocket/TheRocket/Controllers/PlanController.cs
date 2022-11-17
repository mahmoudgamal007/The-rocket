using AutoMapper;
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TheRocket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanRepository Plan;
        public PlanController(IPlanRepository plan)
        {
            Plan=plan;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            return Ok(Plan.GetAllPlans());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            return Ok(Plan.GetPlanById(id));
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPlanByName(string name)
        {
            return Ok(Plan.GetPlanByName(name));
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlan(int id)
        {
            return Ok(Plan.DeletePlan(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlan(Plan plan)
        {
            return Ok(Plan.UpdatePlan(plan));
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewPlan(Plan plan)
        {
            return Ok(Plan.CreatePlan(plan));
        }

    }
}
