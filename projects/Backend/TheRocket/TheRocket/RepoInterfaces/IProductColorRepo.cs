using TheRocket.Dtos.ProductDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IProductColorRepo
    {
         public Task<SharedResponse<ProductColorDto>> AssignColorsToProdcut(ProductColorDto model);
         public Task<SharedResponse<ProductColorDto>> UnAssignColorsToProdcut(ProductColorDto model);
    }
}