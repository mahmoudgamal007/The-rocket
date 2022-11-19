using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IPhoneRepo:IBaseRepo<SharedResponse<PhoneDto>,PhoneDto>
    {
          public Task<SharedResponse<List<PhoneDto>>> GetPhonesByUserId(string AppUserId);
    }
}