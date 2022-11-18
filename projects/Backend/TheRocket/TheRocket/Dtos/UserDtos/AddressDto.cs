namespace TheRocket.Dtos.UserDtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Government { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AppUserId { get; set; }
    }
}