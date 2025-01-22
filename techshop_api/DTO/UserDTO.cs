namespace techshop_api.DTO
{
    public class UserCreateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
