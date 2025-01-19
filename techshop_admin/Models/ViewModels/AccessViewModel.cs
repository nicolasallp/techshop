using System.ComponentModel.DataAnnotations;

namespace techshop_admin.Models.ViewModels
{
    public class AccessViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the email.")]
        public string Email { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the password.")]
        public string? Password { get; set; }
    }
}
