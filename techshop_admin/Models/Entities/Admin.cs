using Newtonsoft.Json;

namespace techshop_admin.Models.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}
