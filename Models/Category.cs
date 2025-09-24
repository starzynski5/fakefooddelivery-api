using System.Text.Json.Serialization;

namespace fakefooddelivery_api.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Meal> Meals { get; set; } = new List<Meal>();

        public Category() { }
    }
}
