using AutoMapper;
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Shared;

namespace TheRocket.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IPlanRepository Plan;
        private readonly TheRocketDbContext Context;
        public PlanController(IPlanRepository plan,TheRocketDbContext context)
        {
            Plan=plan;
            Context=context;
        }
        [HttpGet]
        public async Task<ActionResult<List<PlanDto>>> GetAll()
        {
            SharedResponse<List<PlanDto>> response = await plan.GetAddressesByUserId(userId);
            if (response.status==Status.notFound) return NotFound();
            return response.data;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            var p = Context.Plans.FirstOrDefault(p => p.Id==id && p.IsDeleted==false);
            if (p!=null)
                return Ok(await Plan.GetPlanById(id));
            else
                return NotFound();
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPlanByName(string name)
        {
            var p = Context.Plans.FirstOrDefault(p => p.Name.ToLower()==name.ToLower() && p.IsDeleted==false);
            if (p!=null)
                return Ok(await Plan.GetPlanByName(name));
            else
                return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var p = Context.Plans.FirstOrDefault(p => p.Id==id && p.IsDeleted==false);
            if (p!=null)
                return Ok(await Plan.DeletePlan(id));
            else
                return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlan(PlanDto plan)
        {
            var p = Context.Plans.FirstOrDefault(p => p.Id==plan.Id && p.IsDeleted==false);
            if (p!=null)
                return Ok(await Plan.UpdatePlan(plan));
            else
                return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewPlan(PlanDto plan)
        {
            return Ok(await Plan.CreatePlan(plan));
        }

    }
}
