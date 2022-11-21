using AutoMapper;
using TheRocket.Dtos;
using TheRocket.Entities;


namespace TheRocket.AutoMapper
{
    public class ReserveCartMapper : Profile
    {
        public ReserveCartMapper()
        {
            CreateMap<ReserveCartDto, ReserveCart>().ReverseMap();

        }
    }
}



