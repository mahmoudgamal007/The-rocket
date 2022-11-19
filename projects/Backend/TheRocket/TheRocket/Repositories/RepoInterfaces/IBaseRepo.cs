using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IBaseRepo<T1,T2>
    {
         public Task<List<T1>> GetAll();
         public Task<T1> GetById(int Id);
         public Task<T1> Create(T2 model);
         public Task<T1> Update(int Id,T2 model);
         public Task<T1> Delete(int Id);

         public bool IsExists(int Id);
    }
}