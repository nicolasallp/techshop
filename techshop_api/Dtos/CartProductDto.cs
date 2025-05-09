namespace techshop_api.Dtos
{
    public class CartProductCreateDto
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CartProductUpdateDto
    {
        public string? UserId { get; set; }
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
