namespace API.DTOs
{
    public class UpdateRequestDto
    {
        public int RequestCode { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
