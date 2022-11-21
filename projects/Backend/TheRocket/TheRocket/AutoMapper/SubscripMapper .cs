using TheRocket.Entities;
using TheRocket.Dtos;
using AutoMapper;

namespace TheRocket.AutoMapper
{
    public class SubscripMapper : Profile
    {
        public SubscripMapper()
        {
            CreateMap<SubscripDto, Subscrip>().ReverseMap();
        }
    }
}

