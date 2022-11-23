using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.UserDtos
{
    public class SellerDto
    {
        
        public int SellerId { get; set; }
        public string? ReferalCode { get; set; }
        public int Points { get; set; } = 0;
        public string About { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public string? AppUserId { get; set; }
    }
}