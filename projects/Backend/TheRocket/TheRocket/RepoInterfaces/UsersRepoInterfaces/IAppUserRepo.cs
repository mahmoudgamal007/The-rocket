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
        public Task<SharedResponse<BuyerDto>> GeBuyerByAccountId(int id);
        public Task<SharedResponse<SellerDto>> GeSellerByAccountId(int id);
        public Task<SharedResponse<AppUserDto>> GetAppUserByBuyrId(int id);
        public Task<bool> IsExist(string email);
        public Task<SharedResponse<AppUserDto>> Update(Guid Id, UpdateAppUserDto model);
        public Task<SharedResponse<bool>> Delete(string Id);
    }
}