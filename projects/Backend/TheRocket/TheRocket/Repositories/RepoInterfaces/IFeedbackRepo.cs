using TheRocket.Dtos;
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
        Task<Feedback> GetById(int ProductId, int BuyerId);
        Task<Feedback> AddFeedback(FeedbackDto feedback);


    }
}
