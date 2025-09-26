using System.Text.Json.Serialization;

namespace fakefooddelivery_api.Models
{
    public class Meal
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        public Restaurant Restaurant { get; set; }
        
        public Meal() { }
    }
}
