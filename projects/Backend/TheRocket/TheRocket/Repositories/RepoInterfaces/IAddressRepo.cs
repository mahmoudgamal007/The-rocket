using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IAddressRepo:IBaseRepo<SharedResponse<AddressDto>,AddressDto>
    {
          public Task<SharedResponse<List<AddressDto>>> GetAddressesByUserId(string AppUserId);
    }
}