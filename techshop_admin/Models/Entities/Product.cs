namespace techshop_admin.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public byte[]? Image { get; set; }
        public int Availability { get; set; }
    }
}
