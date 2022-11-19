using TheRocket.Entities;
using TheRocket.Repositories.RepoInterfaces;
using System.Threading.Tasks;
using TheRocket.TheRocketDbContexts;
using Microsoft.AspNetCore.Mvc;
using TheRocket.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TheRocket.Repositories
{
    
    public class PlanRepository : IPlanRepository
    {
        private readonly IMapper Mapper;
        private readonly TheRocketDbContext Context;
        public PlanRepository(TheRocketDbContext context, IMapper mapper)
        {
            Context=context;
            Mapper=mapper;
        }
        public async Task<PlanDto> CreatePlan(PlanDto plan)
        {
            var p = new Plan();
            Mapper.Map(plan, p);
            Context.Plans.Add(p);
            await Context.SaveChangesAsync();
            return plan;

           
        }

        public async Task<List<Plan>> DeletePlan(int id)
        {
            var p=await Context.Plans.FirstOrDefaultAsync(p =>p.Id==id && p.IsDeleted==false);
            p.IsDeleted=true;
            await Context.SaveChangesAsync();
            return await Context.Plans.Where(p=>p.IsDeleted==false).ToListAsync();
        }

        public async Task<List<PlanDto>> GetAllPlans()
        {
                
             List<Plan>Plans = Context.Plans.Where(p=>p.IsDeleted==false).ToList();
             List<PlanDto> plans=new List<PlanDto>();
            foreach(var item in Plans)
            {
                var p = new PlanDto();
                Mapper.Map(item, p);
                plans.Add(p);
            }
             return  plans;
        }

        public async Task<PlanDto> GetPlanById(int id)
        {

            return await Context.Plans.FirstOrDefaultAsync(p => p.Id==id && p.IsDeleted==false);
        }

        public async Task<Plan> GetPlanByName(string name)
        {
            return await Context.Plans.FirstOrDefaultAsync(p => p.Name.ToLower()==name.ToLower() && p.IsDeleted==false);
        }

        public async Task<List<Plan>> UpdatePlan(PlanDto plan)
        {
            var Plan = new Plan();
            var p = await Context.Plans.FirstOrDefaultAsync(p => p.Id==plan.Id && p.IsDeleted==false);
            Mapper.Map(plan,p);
            await Context.SaveChangesAsync();
            return await Context.Plans.ToListAsync();
        }
    }
}
