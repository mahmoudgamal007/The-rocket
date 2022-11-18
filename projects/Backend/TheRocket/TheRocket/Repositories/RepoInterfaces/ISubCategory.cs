
using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Entities.Products;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface ISubCategory
    {

       Task< List<SubCategory>> GetAll();
       Task< List<Product>> GetAllProducts();
       Task< SubCategory> GetById(int id);
       Task< SubCategory >Create(SubCategoryDto subCategory);
        Task<List<SubCategory>> Update(SubCategoryDto subCategory);
        Task<List<SubCategory>> Delete(int id);
    }
}
