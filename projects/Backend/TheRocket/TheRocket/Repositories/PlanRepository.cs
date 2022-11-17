using TheRocket.Entities;
using TheRocket.Repositories.RepoInterfaces;
using System.Threading.Tasks;
using TheRocket.TheRocketDbContexts;
using Microsoft.AspNetCore.Mvc;

namespace TheRocket.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly TheRocketDbContext Context;
        public PlanRepository(TheRocketDbContext context)
        {
            Context=context;       
        }
        public async Task<Plan> CreatePlan(Plan plan)
        {
           Context.Plans.Add(plan);
            await Context.SaveChangesAsync();
            return plan;

           
        }

        public Task DeletePlan(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Plan>> GetAllPlans()
        {
            throw new NotImplementedException();
        }

        public Task<Plan> GetPlanById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Plan> GetPlanByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Plan> UpdatePlan(Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
