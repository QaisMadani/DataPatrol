using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("UserInfo")]
    public class User
    {
        [Key]
        [Column(TypeName = "nvarchar(30)")]
        public string UserId { get; set; } = default!;
        [Column(TypeName = "nvarchar(200)")]
        public string Username { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public ICollection<UserUserGroup> UserGroups { get; set; } = new List<UserUserGroup>();
        public ICollection<UserRequest> UserRequests { get; set; } = new List<UserRequest>();
    }
}
