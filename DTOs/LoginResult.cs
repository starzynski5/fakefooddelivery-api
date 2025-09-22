namespace fakefooddelivery_api.DTOs
{
    public class LoginResult
    {
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

        public string? Token { get; set; }
    }
}
