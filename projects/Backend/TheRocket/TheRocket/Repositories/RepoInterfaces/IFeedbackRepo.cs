using TheRocket.Dtos;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;
using TheRocket.Shared;
    namespace TheRocket.Repositories.RepoInterfaces
    {
    public interface IFeedbackRepo: IBaseRepo<SharedResponse<FeedbackDto>, FeedbackDto>
        {
        public Task<SharedResponse<List<Product>>> GetAllProducts();
        public Task<SharedResponse<List<Buyer>>> GetAllBuyers();
    }
}
