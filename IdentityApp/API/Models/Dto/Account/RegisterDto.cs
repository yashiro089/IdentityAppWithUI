using System.ComponentModel.DataAnnotations;

namespace API.Models.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Firstname must be at least {2} and maximum of {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Lastname must be at least {2} and maximum of {1} characters")]
        public string LastName { get; set; }
        [Required]
        //[EmailAddress(ErrorMessage = "Email Address Invalid")]
        [EmailAddress(ErrorMessage = "Email Address Invalid")]
        public string Email { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must be at least {2} and maximum of {1} characters")]
        public string Password { get; set; }
    }
}
