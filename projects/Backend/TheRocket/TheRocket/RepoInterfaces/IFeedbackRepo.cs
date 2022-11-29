using TheRocket.Dtos;
using TheRocket.Shared;
    namespace TheRocket.Repositories.RepoInterfaces
    {
    public interface IFeedbackRepo: IBaseRepo<SharedResponse<FeedbackDto>, SharedResponse<List<FeedbackDto>>, FeedbackDto>
        {

            public Task<SharedResponse<List<FeedbackDto>>> GetAllFeedbacsByProductId(int ProdcutId);

    }
}
