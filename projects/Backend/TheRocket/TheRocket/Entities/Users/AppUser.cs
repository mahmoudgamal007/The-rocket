using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TheRocket.Entities;
using TheRocket.Entities.Users;

namespace TheRocket.Entities.Users
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            Addresses=new();
            PhoneNumbers=new();
            Locations=new();
        }
        
        public virtual Seller? Seller { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public virtual Admin? Admin { get; set; }

        public virtual List<Phone> PhoneNumbers { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual List<Location>? Locations{get; set;}
        
    }


   
}