using TheRocket.Dtos.ProductDtos;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IProductImgUrlRepo:IBaseRepo<SharedResponse<ProductImgUrlDto>,SharedResponse<List<ProductImgUrlDto>>,ProductImgUrlDto>
    {
          public Task<SharedResponse<List<ProductImgUrlDto>>> GetImgUrlByProductId(int ProductId);
    }
}