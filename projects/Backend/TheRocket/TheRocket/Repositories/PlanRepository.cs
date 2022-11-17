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
        public async Task<Plan> CreatePlan(Plan plan)
        {
           Context.Plans.Add(plan);
            await Context.SaveChangesAsync();
            return plan;

           
        }

        public async Task DeletePlan(int id)
        {
            var p=await Context.Plans.FirstOrDefaultAsync(p =>p.Id==id);
            p.IsDeleted=true;
            UpdatePlan(p);
        }

        public async Task<List<Plan>> GetAllPlans()
        {
           
                return await Context.Plans.ToListAsync();
        }

        public async Task<Plan> GetPlanById(int id)
        {
            return await Context.Plans.FirstOrDefaultAsync(p => p.Id==id);
        }

        public async Task<Plan> GetPlanByName(string name)
        {
            return await Context.Plans.FirstOrDefaultAsync(p => p.Name.ToLower()==name.ToLower());
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            var p = await Context.Plans.FirstOrDefaultAsync(p => p.Id==plan.Id);
            Mapper.Map(p, plan);
            return plan;
        }
    }
}
