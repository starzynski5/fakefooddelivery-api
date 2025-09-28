using System.Text.Json.Serialization;

namespace fakefooddelivery_api.Models
{
    public class Order
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Meal Meal { get; set; }
        public int MealId { get; set; }

        [JsonIgnore]
        public User Client { get; set; }
        public int ClientId { get; set; }

        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        public int RestaurantId { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedAtDate {  get; set; }

        public Order() { 
            CreatedAtDate = DateTime.UtcNow;
            Status = Status.WaitingForTheOrderToBeAccepted;
        }
    }
}
