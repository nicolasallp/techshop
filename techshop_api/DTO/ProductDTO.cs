namespace techshop_api.DTO
{
    public class ProductCreateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Image { get; set; }
        public int Availability { get; set; }
    }
}
