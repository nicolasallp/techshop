using System.ComponentModel.DataAnnotations;

namespace techshop.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the first name.")]
        public string? FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the last name.")]
        public string? LastName { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the email.")]
        public string? Email { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the password.")]
        public string? Password { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm the password.")]
        public string? ConfirmPassword { get; set; }
    }
}
