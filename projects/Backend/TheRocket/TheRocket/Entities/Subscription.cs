namespace TheRocket.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; } // it's in ERD but isnt that supposed to be inherited?
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }
        public int Discount { get; set; }
        public Double Price { get; set; }
        public string CreatedBy { get; set; } 



    }
}
