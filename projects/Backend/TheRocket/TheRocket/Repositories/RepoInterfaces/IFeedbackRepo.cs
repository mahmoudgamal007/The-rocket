using TheRocket.Dtos;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Repositories
{
    public interface IFeedbackRepo
    {


        Task<List<Feedback>> GetAllFeedbacks();
        Task<List<Product>> GetAllProducts();
        Task<List<Buyer>> GetAllBuyers();
        Task<Feedback> GetById(int ProductId, int BuyerId);
        Task<FeedbackDto> AddFeedback(FeedbackDto feedback);
        Task<List<Feedback>> UpdateFeedback(int ProductId, int BuyerId,FeedbackDto feedback);


    }
}
