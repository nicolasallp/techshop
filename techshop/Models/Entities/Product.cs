namespace techshop.Models.Entities
{
    public class Product
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public string? Image { get; set; }
        public int Availability { get; set; }
    }
}
