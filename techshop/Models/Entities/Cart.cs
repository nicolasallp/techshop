using System.ComponentModel.DataAnnotations.Schema;

namespace techshop.Models.Entities
{
    public class Cart
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
