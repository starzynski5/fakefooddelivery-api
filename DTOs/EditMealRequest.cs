namespace fakefooddelivery_api.DTOs
{
    public class EditMealRequest
    {
        public int MealId { get; set; }

        public string NewName { get; set; }

        public string NewDescription { get; set; }

        public float NewPrice { get; set; }
    }
}
