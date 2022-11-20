using TheRocket.Entities;
using TheRocket.Dtos;
using AutoMapper;
namespace TheRocket.AutoMapper
{
    public class OrderMapper:Profile
    {
        public OrderMapper()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
        }
    }
}
