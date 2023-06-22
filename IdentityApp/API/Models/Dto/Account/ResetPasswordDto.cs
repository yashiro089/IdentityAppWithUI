using System.ComponentModel.DataAnnotations;

namespace API.Models.Dto.Account
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email Address Invalid")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "New Password must be at least {2} and maximum of {1} characters")]
        public string NewPassword { get; set; }
    }
}
