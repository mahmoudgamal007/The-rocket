using System;
using AutoMapper;
using TheRocket.Dtos.UserDtos;
using TheRocket.Entities.Users;

namespace TheRocket.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SellerDto, AppUser>().ReverseMap();
            CreateMap<SellerDto, Seller>().ReverseMap();
            CreateMap<BuyerDto, AppUser>().ReverseMap();
            CreateMap<BuyerDto, Buyer>().ReverseMap();
            CreateMap<AdminDto, AppUser>().ReverseMap();
            CreateMap<AdminDto, Admin>().ReverseMap();
            CreateMap<AddressDto,Address>().ReverseMap();
            CreateMap<PhoneDto,Phone>().ReverseMap();
            CreateMap<LocationDto,Location>().ReverseMap();
        }
    }
}

