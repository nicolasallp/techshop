namespace techshop_api.Dtos
{
    public class ProductCreateDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? ImageData { get; set; }
        public int Availability { get; set; }
    }
}
