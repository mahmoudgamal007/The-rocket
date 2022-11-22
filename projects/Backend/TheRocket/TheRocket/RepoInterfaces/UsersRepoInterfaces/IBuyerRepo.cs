using TheRocket.Dtos.UserDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IBuyerRepo : IBaseRepo<SharedResponse<BuyerDto>, SharedResponse<List<BuyerDto>>, BuyerDto>
    {
        public Task<SharedResponse<BuyerDto>> GetByUserId(string AppUserId);

    }
}