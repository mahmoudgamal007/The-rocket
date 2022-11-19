using TheRocket.Dtos.UserDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IBuyerRepo:IBaseRepo<SharedResponse<BuyerDto>,BuyerDto>
    {
         
    }
}