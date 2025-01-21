using System.ComponentModel.DataAnnotations;

namespace techshop_admin.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the product name.")]
        public string? Name { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the product description.")]
        public string? Description { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the product price.")]
        public string? Price { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Provide the product brand.")]
        public string? Brand { get; set; }
        public int Availability { get; set; }
    }
}
