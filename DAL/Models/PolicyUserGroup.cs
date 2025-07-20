using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class PolicyUserGroup
    {
        public string PolicyId { get; set; } = default!;
        public string GroupId { get; set; } = default!;
        [JsonIgnore]

        public Policy? Policy { get; set; }
        [JsonIgnore]

        public UserGroup? Group { get; set; }
    }
}
