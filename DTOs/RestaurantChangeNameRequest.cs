namespace fakefooddelivery_api.DTOs
{
    public class RestaurantChangeNameRequest
    {
        public string NewName { get; set; }

        public int RestaurantId { get; set; }
    }
}
