using System.ComponentModel.DataAnnotations;

namespace Event_System.Core.Entity.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = "";
    }
}
