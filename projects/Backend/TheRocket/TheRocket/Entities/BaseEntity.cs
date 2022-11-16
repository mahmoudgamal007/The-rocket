using System;
namespace TheRocket.Entities
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy {get;set;}
    }
}

