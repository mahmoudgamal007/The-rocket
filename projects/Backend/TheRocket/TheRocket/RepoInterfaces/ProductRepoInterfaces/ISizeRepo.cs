using TheRocket.Dtos.ProductDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface ISizeRepo:IBaseRepo<SharedResponse<SizeDto>,SharedResponse<List<SizeDto>>,SizeDto>
    {
         
    }
}