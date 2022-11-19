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
        public Task<SharedResponse<List<FeedbackDto>>> GetAllFeedbacks();
        public Task<SharedResponse<List<FeedbackDto>>> GetFeedbackbyId(int ProductId, int BuyerId);
        public Task<SharedResponse<FeedbackDto>> UpdateFeedback(int ProductId, int BuyerId, FeedbackDto model);
        public bool IsExist(int ProductId,int BuyerId);
        public Task<SharedResponse<FeedbackDto>> DeleteFeedback(int ProductId, int BuyerId);


    }
}
