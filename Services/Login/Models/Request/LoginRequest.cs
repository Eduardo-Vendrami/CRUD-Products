using Newtonsoft.Json;

namespace CRUD_Products.Models.Login.Models.Request
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("isSeller")]
        public bool IsSeller { get; set; }

        [JsonProperty("isCustomer")]
        public bool IsCustomer { get; set; }
    }
}
