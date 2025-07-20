namespace API.DTOs
{
    public class UpdatePolicyDto
    {
        public string PolicyName { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public int PolicyType { get; set; }
        public bool IsEnabled { get; set; }
    }
}
