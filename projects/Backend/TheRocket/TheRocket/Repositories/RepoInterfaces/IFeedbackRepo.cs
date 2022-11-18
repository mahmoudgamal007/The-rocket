using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Repositories
{
    public interface IFeedbackRepo
    {


        IEnumerable<Feedback> GetAllFeedbacks();
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Buyer> GetAllBuyers();

        //Task<List<Feedback>> GetAllFeedbacks();
        //Task<List<Product>> GetAllProducts();
        //Task<List<Buyer>> GetAllBuyers();
        Task<Feedback> GetById(int ProductId, int BuyerId);

    }
}
