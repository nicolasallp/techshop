namespace techshop.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Fee { get; set; }
        public string? Status { get; set; }
    }
}
