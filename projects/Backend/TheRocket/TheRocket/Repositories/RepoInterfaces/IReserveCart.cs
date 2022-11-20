using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IReserveCart : IBaseRepo <SharedResponse<ReserveCartDto>, SharedResponse<List<ReserveCartDto>>, ReserveCartDto>
    {
    }
}
