namespace fakefooddelivery_api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "USER";

        public DateTime CreatedAtDate { get; set; }

        public User() {
            CreatedAtDate = DateTime.UtcNow;
        }
    }
}
