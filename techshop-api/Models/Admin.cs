using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("tb_admin")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }
    }
}
