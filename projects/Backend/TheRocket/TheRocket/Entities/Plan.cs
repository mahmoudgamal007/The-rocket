namespace TheRocket.Entities
{
    public class Plan:BaseEntity
    {
        public int PlanId { get; set; }//just Id
        public string PlanName { get; set; }//just Name
        public string Description { get; set; }
        public double CurrentPrice { get; set; }//Price
        public int Duration { get; set; }
        public DateTime CreatedDate { get; set; }//remove
        public int Discount { get; set; }
        public string CreatedBy { get; set; }//remove
        public bool IsDeleted { get; set; } //remove

    }
}
