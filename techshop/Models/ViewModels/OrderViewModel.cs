using System.ComponentModel.DataAnnotations;

namespace techshop.Models.ViewModels
{
    public class OrderViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the Address")]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the City")]
        public string? City { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the State")]
        public string? State { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the ZIP/Postal Code")]
        public string? PostalCode { get; set; }
    }
}
