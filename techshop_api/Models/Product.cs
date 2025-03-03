﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace techshop_api.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id")]
        [MaxLength(36)]
        public string? Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        public string? Name { get; set; }
        
        [Column("description")]
        [MaxLength(500)]
        public string? Description { get; set; }

        [Column("price")]
        [Precision(6, 2)]
        public decimal Price { get; set; }

        [Column("brand")]
        [MaxLength(50)]
        public string? Brand { get; set; }

        [Column("image")]
        public string? Image { get; set; }
        
        [Column("availability")]
        public int Availability { get; set; }
    }
}
