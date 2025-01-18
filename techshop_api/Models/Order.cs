using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("fee")]
        [Precision(4, 2)]
        public decimal Fee { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string? Status { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
