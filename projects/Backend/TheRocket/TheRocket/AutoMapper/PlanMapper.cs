using TheRocket.Entities;
using TheRocket.Dtos;
using AutoMapper;
namespace TheRocket.AutoMapper
{
    public class PlanMapper:Profile
    {
        public PlanMapper()
        {
            CreateMap<PlanDto, Plan>();
        }
    }
}
