using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IOrderRepo : IBaseRepo<SharedResponse<OrderDto>, SharedResponse<List<OrderDto>>, OrderDto>
    {

    }
}
