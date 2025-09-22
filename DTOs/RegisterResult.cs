namespace fakefooddelivery_api.DTOs
{
    public class RegisterResult
    {
        public bool Success { get; set; }

        public string? Token { get; set; }

        public string? ErrorMessage { get; set; }

        public RegisterResult() { }

    }
}
