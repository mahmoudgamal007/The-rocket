
using AutoMapper;
using TheRocket.Dtos;
using TheRocket.Entities;

namespace AuotMapper
{
    public class SubCategoryMapper : Profile
    {
        public SubCategoryMapper()
        {
            CreateMap< SubCategoryDto, SubCategory>();
                
        }
    }
}