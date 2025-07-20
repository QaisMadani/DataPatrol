using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserGroup
    {
        [Key]
        [Column(TypeName = "nvarchar(30)")]
        public string GroupId { get; set; } = default!;
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = default!;
        public ICollection<UserUserGroup> UserUsers { get; set; } = new List<UserUserGroup>();
        public ICollection<PolicyUserGroup> Policies { get; set; } = new List<PolicyUserGroup>();
    }
}
