using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [Column("email")]
        [MaxLength(100)]
        public string? Email { get; set; }

        [Column("password")]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Column("address1")]
        [MaxLength(100)]
        public string? Address1 { get; set; }

        [Column("address2")]
        [MaxLength(100)]
        public string? Address2 { get; set; }

        [Column("city")]
        [MaxLength(50)]
        public string? City { get; set; }

        [Column("state")]
        [MaxLength(50)]
        public string? State { get; set; }

        [Column("postal_code")]
        [MaxLength(30)]
        public string? PostalCode { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
