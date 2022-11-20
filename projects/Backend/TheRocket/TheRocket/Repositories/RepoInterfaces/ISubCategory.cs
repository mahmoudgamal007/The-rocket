using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface ISubCategory:IBaseRepo<SharedResponse<SubCategoryDto>,SharedResponse<List<SubCategoryDto>>, SubCategoryDto>
    {



       
    }
}
