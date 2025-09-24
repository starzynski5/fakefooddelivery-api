namespace fakefooddelivery_api.DTOs
{
    public class MealWithCategoryNameDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }

        public string CategoryName { get; set; }

        public string RestaurantName { get; set; }

        public int RestaurantId { get; set; }

        public MealWithCategoryNameDTO() { }
    }
}
