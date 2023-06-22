using System.ComponentModel.DataAnnotations;

namespace API.Models.Dto.Account
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Password { get; set; }
    }
}
