using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RequestId { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        [Column(TypeName = "nvarchar(30)")]
        public string RequestedBy { get; set; } = default!;
        public DateTime RequestDateTime { get; set; } = DateTime.UtcNow;
        public int RequestCode { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = default!;
        public RequestStatus Status { get; set; } = RequestStatus.Draft;
        public DateTime? CompletionDateTime { get; set; }
        public User? User { get; set; }
    }

    public enum RequestStatus
    {
        Draft = 0,
        InReview = 1,
        Approved = 2,
        Rejected = 3,
        Error = 4
    }

}
