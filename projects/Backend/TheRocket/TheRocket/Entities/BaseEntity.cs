using System;
namespace TheRocket.Entities
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set;}
        // public int CreatedBy {get;set;}


    }
}

