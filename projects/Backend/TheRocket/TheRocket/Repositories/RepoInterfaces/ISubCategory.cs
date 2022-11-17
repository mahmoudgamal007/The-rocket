
using TheRocket.Entities;
using TheRocket.Entities.Products;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface ISubCategory
    {

       Task< List<SubCategory>> GetAll();
       Task< List<Product>> GetAllProducts();
       Task< SubCategory> GetById(int id);
       Task< SubCategory >Add(SubCategory subCategory);
        Task<SubCategory?> Update(SubCategory subCategory);
    }
}
