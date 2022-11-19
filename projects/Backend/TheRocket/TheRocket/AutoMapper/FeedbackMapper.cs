using TheRocket.Entities;
using TheRocket.Dtos;
using AutoMapper;

namespace TheRocket.AutoMapper
{
    public class FeedbackMapper : Profile
    {
        public FeedbackMapper()
        {
            CreateMap< FeedbackDto, Feedback>();
        }
    }
}

