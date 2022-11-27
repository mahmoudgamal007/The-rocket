using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos.UserDtos
{
    public class UpdateAppUserDto
    {
        public UpdateAppUserDto()
        {
            Addresses = new();
            PhoneNumbers = new();
            Locations = new();
        }
        public Guid? Id { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        // [DataType(DataType.Password)]
        // public string Password { get; set; }

        // [Compare(nameof(Password), ErrorMessage = "Confirm password doesn't match, Type again !")]
        // public string ConfirmPassword { get; set; }
        public virtual SellerDto? Seller { get; set; }

        public virtual BuyerDto? Buyer { get; set; }
        public virtual AdminDto? Admin { get; set; }

        public virtual List<PhoneDto>? PhoneNumbers { get; set; }

        public virtual List<AddressDto>? Addresses { get; set; }

        public virtual List<LocationDto>? Locations { get; set; }


    }

}