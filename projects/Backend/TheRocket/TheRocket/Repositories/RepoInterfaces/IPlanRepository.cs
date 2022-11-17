using TheRocket.Entities;
namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetAllPlans();
        Task<Plan> GetPlanById(int id);
        Task<Plan> GetPlanByName(string name);  
        Task<Plan>CreatePlan(Plan plan);
        Task<Plan> UpdatePlan(Plan plan);   
        Task DeletePlan(int id);
    }
}
