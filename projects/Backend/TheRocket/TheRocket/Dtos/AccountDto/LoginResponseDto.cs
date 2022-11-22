using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos.AccountDto
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string? BrandName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string JwtToken { get; set; }
        public string AccountType { get; set; }
    }
}