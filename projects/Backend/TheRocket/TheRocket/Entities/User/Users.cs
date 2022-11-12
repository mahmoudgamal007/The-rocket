using System.ComponentModel.DataAnnotations;
using TheRocket.Entities;
using TheRocket.Entities.Users;

namespace TheRocket.EntitiesUsers
{
    public class User:BaseEntity
    {
        public User()
        {
            Addresses=new();
            Phones=new();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email{get;set;}
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }

        //custompropery
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public virtual List<Phone> Phones { get; set; }

        public virtual List<Address> Addresses { get; set; }
        
    }

    public enum Gender{
        Male=0,Female=1
    }
}