using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("review")]
    public class Review
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

        [Column("rating")]
        public int Rating { get; set; }
        
        [Column("review_text")]
        [MaxLength(500)]
        public string? ReviewText { get; set; }
        
        [Column("created_date")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
