using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.UserDtos
{
    public class AdminDto
    {
       
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string? AppUserId { get; set; }
      
    }
}