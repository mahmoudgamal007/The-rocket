using TheRocket.Entities;
using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IPlanRepository : IBaseRepo<SharedResponse<PlanDto>, PlanDto,SharedResponse<List<PlanDto>>>
    {
        Task<Plan> GetPlanByName(string name);  
      
    }
}
