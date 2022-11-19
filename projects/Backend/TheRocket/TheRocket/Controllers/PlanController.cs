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
            SharedResponse<List<PlanDto>> response = await Plan.GetAll();
            if (response.status==Status.notFound) return NotFound();
            return Ok(response.data);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            SharedResponse<PlanDto> response = await Plan.GetById(id);
            if (response.status==Status.notFound) return NotFound();
            return Ok(response.data);
        
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PlanDto>> DeleteAddress(int id)
        {
            SharedResponse<PlanDto> response = await Plan.Delete(id);
            if (response.status==Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PlanDto>> PutAddress(int id, PlanDto plan)
        {
            SharedResponse<PlanDto> response = await Plan.Update(id, plan);
            if (response.status==Status.badRequest) return BadRequest();
            else if (response.status==Status.notFound) return NotFound();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<PlanDto>> PostAddress(PlanDto plan)
        {
            SharedResponse<PlanDto> response = await Plan.Create(plan);
            if (response.status==Status.problem) return Problem(response.message);
            if (response.status==Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

    }
}
