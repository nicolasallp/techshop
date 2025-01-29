using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        public string? Id { get; set; }

        [Column("product_id")]
        [MaxLength(36)]
        public string? ProductId { get; set; }

        [Column("user_id")]
        [MaxLength(36)]
        public string? UserId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string? Status { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
