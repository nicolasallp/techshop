using System.ComponentModel.DataAnnotations;

namespace techshop.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the email.")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the password.")]
        public string? Password { get; set; }
    }
}
