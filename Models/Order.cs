namespace fakefooddelivery_api.Models
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

        public User Client { get; set; }

        public Restaurant Restaurant { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedAtDate {  get; set; }

        public Order() { 
            CreatedAtDate = DateTime.UtcNow;
        }
    }
}
