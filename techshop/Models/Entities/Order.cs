namespace techshop.Models.Entities
{
    public class Order
    {
        public string? ProductId { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; }
        public string? Status { get; set; }
    }
}
