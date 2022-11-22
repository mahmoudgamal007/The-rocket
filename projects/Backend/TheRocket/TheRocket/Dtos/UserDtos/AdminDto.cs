using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.UserDtos
{
    public class AdminDto
    {
            //AppUser
        public int AdminId { get; set; }

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

        //Admin
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? AppUserId { get; set; }

        public AppUser AppUser { get; set; }
        
        //Identity Result
        public IdentityResult? IdentityResult { get; set; }
    }
}