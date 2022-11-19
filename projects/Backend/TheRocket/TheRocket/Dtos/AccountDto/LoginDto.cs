using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos.AccountDto
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}