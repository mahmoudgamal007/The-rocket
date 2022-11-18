using TheRocket.Entities;
using TheRocket.Dtos;
namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetAllPlans();
        Task<Plan> GetPlanById(int id);
        Task<Plan> GetPlanByName(string name);  
        Task<Plan>CreatePlan(PlanDto plan);
        Task<List<Plan>> UpdatePlan(PlanDto plan);   
        Task<List<Plan>> DeletePlan(int id);
    }
}
