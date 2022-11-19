using TheRocket.Entities;
using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IPlanRepository : IBaseRepo<SharedResponse<PlanDto>, SharedResponse<List<PlanDto>>, PlanDto>
    {
       
      
    }
  
}
