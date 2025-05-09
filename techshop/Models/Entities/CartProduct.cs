using System.ComponentModel.DataAnnotations.Schema;

namespace techshop.Models.Entities
{
    public class CartProduct
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
