namespace techshop_api.Dtos
{
    public class OrderCreateDto
    {
        public string? ProductId { get; set; }
        public string? UserId { get; set; }
        public int Quantity { get; set; }
    }
}
