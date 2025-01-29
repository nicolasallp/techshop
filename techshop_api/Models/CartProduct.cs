using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("cart_product")]
    public class CartProduct
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        public string? Id { get; set; }

        [Column("user_id")]
        public string? UserId { get; set; }
        
        [Column("product_id")]
        public string? ProductId { get; set; }
        
        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
