using TheRocket.Dtos.AccountDto;
using TheRocket.Dtos.UserDtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.RepoInterfaces.UsersRepoInterfaces
{
    public interface IAppUserRepo
    {
         public Task<SharedResponse<LoginResponseDto>> Create(AppUserDto model);
    }
}