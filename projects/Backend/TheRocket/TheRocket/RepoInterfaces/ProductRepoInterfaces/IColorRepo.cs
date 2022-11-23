using TheRocket.Dtos.ProductDtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IColorRepo : IBaseRepo<SharedResponse<ColorDto>, SharedResponse<List<ColorDto>>, ColorDto>
    {
       public Task<SharedResponse<List<ColorDto>>> GetColorsByIds(List<int> Ids);
    }
}