using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.UserDtos
{
    public class BuyerDto
    {
         //AppUser
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

        //Buyer
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string AppUserId { get; set; }
        
        //Identity Result
        public IdentityResult? IdentityResult { get; set; }
    }
}