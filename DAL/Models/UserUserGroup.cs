using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class UserUserGroup
    {
        public string UserId { get; set; } = default!;
        public string GroupId { get; set; } = default!;
        [JsonIgnore]
        public User? User { get; set; }
        [JsonIgnore]
        public UserGroup? Group { get; set; }
    }
}
