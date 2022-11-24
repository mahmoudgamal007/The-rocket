using TheRocket.Dtos.AccountDto;
using TheRocket.Dtos.UserDtos;
using TheRocket.Repositories.RepoInterfaces;
using TheRocket.Shared;

namespace TheRocket.RepoInterfaces.UsersRepoInterfaces
{
    public interface IAppUserRepo
    {
         public Task<SharedResponse<LoginResponseDto>> Create(AppUserDto model);
          public Task<SharedResponse<List<AppUserDto>>> GetAll();
         public Task<SharedResponse<AppUserDto>> GetById(string id);
        //  public Task<SharedResponse<AppUserDto>> GetByAccountId(int id);
        //  public Task<SharedResponse<AppUserDto>> Update(string Id,AppUserDto model);
        //  public Task<SharedResponse<bool>> Delete(string Id);
    }
}