using TheRocket.Dtos;
using TheRocket.Shared;
    namespace TheRocket.Repositories.RepoInterfaces
    {
    public interface ISubscripRepo: IBaseRepo<SharedResponse<SubscripDto>, SharedResponse<List<SubscripDto>>, SubscripDto>
        {
 
    }
}
