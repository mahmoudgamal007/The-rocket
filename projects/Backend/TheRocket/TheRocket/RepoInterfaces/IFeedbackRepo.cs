using TheRocket.Dtos;
using TheRocket.Shared;
    namespace TheRocket.Repositories.RepoInterfaces
    {
    public interface IFeedbackRepo: IBaseRepo<SharedResponse<FeedbackDto>, SharedResponse<List<FeedbackDto>>, FeedbackDto>
        {

    }
}
