using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; } = default!;
        public string Username { get; set; } = default!;
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
