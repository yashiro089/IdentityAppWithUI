using System.ComponentModel.DataAnnotations;

namespace API.Models.Dto.Account
{
    public class ConfirmEmailDto
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email Address Invalid")]
        public string Email { get; set; }
    }
}
