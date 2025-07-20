using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("PolicyTable")]
    public class Policy
    {
        [Key]
        [Column(TypeName = "nvarchar(30)")]
        public string PolicyId { get; set; } = default!;
        [Column(TypeName = "nvarchar(200)")]
        public string PolicyName { get; set; } = default!;
        public bool IsDefault { get; set; }
        public int PolicyType { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public ICollection<PolicyUserGroup> Groups { get; set; } = new List<PolicyUserGroup>();
    }
}
