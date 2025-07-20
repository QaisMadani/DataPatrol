namespace API.DTOs
{
    public class CreateRequestDto
    {
        public string UserId { get; set; } = string.Empty;
        public int RequestCode { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
