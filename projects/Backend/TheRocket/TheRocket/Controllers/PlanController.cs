using AutoMapper;
using Microsoft.AspNetCore.Http;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Dtos;
using TheRocket.TheRocketDbContexts;
using TheRocket.Entities;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Shared;
using Microsoft.AspNetCore.Authorization;

namespace TheRocket.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class PlanController : ControllerBase
    {
        private readonly IPlanRepository Plan;
        private readonly TheRocketDbContext Context;
        public PlanController(IPlanRepository plan, TheRocketDbContext context)
        {
            Plan = plan;
            Context = context;
        }
        [HttpGet]
        [AllowAnonymous]

        public async Task<ActionResult<List<PlanDto>>> GetAll()
        {
            SharedResponse<List<PlanDto>> response = await Plan.GetAll();
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);
        }
        [HttpGet("[action]")]
        [AllowAnonymous]

        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            SharedResponse<PlanDto> response = await Plan.GetById(id);
            if (response.status == Status.notFound) return NotFound();
            return Ok(response.data);

        }

        [HttpDelete]
        public async Task<ActionResult<PlanDto>> DeletePlan([FromQuery] int id)
        {
            SharedResponse<PlanDto> response = await Plan.Delete(id);
            if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<PlanDto>> PutPlan([FromQuery] int id, PlanDto plan)
        {
            SharedResponse<PlanDto> response = await Plan.Update(id, plan);
            if (response.status == Status.badRequest) return BadRequest();
            else if (response.status == Status.notFound) return NotFound();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<PlanDto>> PostPlan(PlanDto plan)
        {
            SharedResponse<PlanDto> response = await Plan.Create(plan);
            if (response.status == Status.problem) return Problem(response.message);
            if (response.status == Status.badRequest) return BadRequest(response.message);
            return Ok(response.data);
        }

    }
}
