﻿namespace techshop.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
