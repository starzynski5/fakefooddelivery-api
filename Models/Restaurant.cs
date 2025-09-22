namespace fakefooddelivery_api.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public Restaurant(int userId)
        {
            OwnerId = userId;
            CreatedAtDate = DateTime.UtcNow;
        }
    }
}
