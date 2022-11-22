using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.UserDtos
{
    public class SellerDto
    {
        //AppUser
        public int SellerId { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public AddressDto? Addresse { get; set; }

        public PhoneDto? PhoneNumber { get; set; }

        public LocationDto? Location{get; set;}

        //Seller
        public string? ReferalCode { get; set; }
        public int Points { get; set; } = 0;
        public string About { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public string? AppUserId { get; set; }

        //Identity Result
        public IdentityResult? IdentityResult { get; set; }
    }
}