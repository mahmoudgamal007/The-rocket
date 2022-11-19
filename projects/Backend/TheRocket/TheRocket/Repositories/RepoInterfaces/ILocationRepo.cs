using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface ILocationRepo:IBaseRepo<SharedResponse<LocationDto>,SharedResponse<List<LocationDto>>,LocationDto>
    {
          public Task<SharedResponse<List<LocationDto>>> GetLocationsByUserId(string AppUserId);
    }
}