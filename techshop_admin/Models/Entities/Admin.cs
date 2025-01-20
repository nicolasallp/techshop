using Newtonsoft.Json;

namespace techshop_admin.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
