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
            CreateMap<SellerDto, AppUser>();
            CreateMap<SellerDto, Seller>();
            CreateMap<BuyerDto, AppUser>();
            CreateMap<BuyerDto, Buyer>();
            CreateMap<AdminDto, AppUser>();
            CreateMap<AdminDto, Admin>();
            CreateMap<AddressDto,Address>();
            CreateMap<Address,AddressDto>();
            CreateMap<PhoneDto,Phone>();
            CreateMap<Phone,PhoneDto>();
            CreateMap<LocationDto,Location>();
            CreateMap<Location,LocationDto>();
        }
    }
}

