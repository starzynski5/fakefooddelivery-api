namespace fakefooddelivery_api.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public DateTime CreatedAtDate { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

        public Restaurant() { }

        public Restaurant(int userId, User user)
        {
            OwnerId = userId;
            CreatedAtDate = DateTime.UtcNow;
            Owner = user;
        }
    }
}
