using System;
using AutoMapper;
using TheRocket.Dtos.UserDtos;
using TheRocket.Dtos.ProductDtos;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;
using TheRocket.Dtos;
using TheRocket.Entities;

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
            CreateMap<ColorDto,Colour>().ReverseMap();
            CreateMap<SizeDto,Size>().ReverseMap();
            CreateMap<ProductColorDto,ProductColor>().ReverseMap();
            CreateMap<ProductSizeDto,ProductSize>().ReverseMap();
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<ProductDto,AddProductDto>().ReverseMap();
            CreateMap<ProductImgUrlDto,ProductImgUrl>().ReverseMap();
            CreateMap<AppUserDto,AppUser>().ReverseMap();
            CreateMap<UpdateAppUserDto,AppUser>().ReverseMap();
            CreateMap<FeedbackDto, Feedback>().ReverseMap();
            CreateMap<PlanDto, Plan>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap< SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<SubscripDto, Subscrip>().ReverseMap();
            CreateMap<ReserveCartDto, ReserveCart>().ReverseMap();


        }
    }
}

