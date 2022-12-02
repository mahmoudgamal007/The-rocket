using TheRocket.Dtos;
using TheRocket.Shared;

namespace TheRocket.Repositories.RepoInterfaces
{
    public interface IOrderRepo : IBaseRepo<SharedResponse<OrderDto>, SharedResponse<List<OrderDto>>, OrderDto>
    {
         public Task<SharedResponse<List<OrderDto>>> GetBySellerId(int SellerId);
         public Task<SharedResponse<List<OrderDto>>> GetByBuyerId(int BuyerId);
         public Task<SharedResponse<Boolean>> AcceptOrReturnOrder(int orderId,int Amount,bool Accept);
    }
}
